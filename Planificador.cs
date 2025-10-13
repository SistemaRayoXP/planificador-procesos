using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Planificador
{
    public class Planificador
    {
        private readonly List<Proceso> procesos;
        private readonly List<PasoSimulacion> pasos = new();
        private const int MilisegundosPorMinutoPredeterminados = 1000;

        public Planificador(IEnumerable<Proceso> listaProcesos)
        {
            if (listaProcesos is null)
            {
                throw new ArgumentNullException(nameof(listaProcesos));
            }

            procesos = listaProcesos
                .OrderBy(p => p.TiempoLlegada)
                .ToList();
        }

        public IReadOnlyList<Proceso> Ejecutar()
        {
            PlanificarShortestRemainingTime();
            return procesos;
        }

        private void PlanificarShortestRemainingTime()
        {
            pasos.Clear();

            foreach (var proceso in procesos)
            {
                proceso.TiempoInicio = -1;
                proceso.TiempoFin = 0;
                proceso.TiempoEspera = 0;
                proceso.TiempoRetorno = 0;
                proceso.TiempoRespuesta = 0;
                proceso.TiempoRestante = proceso.Duracion;
                proceso.Estado = EstadoProceso.Bloqueado;
                RegistrarPaso(proceso, EstadoProceso.Bloqueado);
            }

            var colaListos = new PriorityQueue<Proceso, (int TiempoRestante, int TiempoLlegada, int Secuencia)>();
            var procesosOrdenados = procesos
                .OrderBy(p => p.TiempoLlegada)
                .ToList();

            var totalProcesos = procesosOrdenados.Count;
            var indiceLlegadas = 0;
            var tiempoActual = 0;
            var contadorSecuencia = 0;

            while (colaListos.Count > 0 || indiceLlegadas < totalProcesos)
            {
                while (indiceLlegadas < totalProcesos && procesosOrdenados[indiceLlegadas].TiempoLlegada <= tiempoActual)
                {
                    var llegado = procesosOrdenados[indiceLlegadas];

                    if (llegado.TiempoRestante > 0)
                    {
                        RegistrarPaso(llegado, EstadoProceso.Listo);
                        colaListos.Enqueue(llegado, (llegado.TiempoRestante, llegado.TiempoLlegada, contadorSecuencia++));
                    }

                    indiceLlegadas++;
                }

                if (colaListos.Count == 0)
                {
                    if (indiceLlegadas < totalProcesos)
                    {
                        var siguiente = procesosOrdenados[indiceLlegadas];

                        if (siguiente.TiempoLlegada > tiempoActual)
                        {
                            var tiempoInactivo = siguiente.TiempoLlegada - tiempoActual;
                            RegistrarPaso(null, EstadoProceso.Bloqueado, tiempoInactivo);
                            tiempoActual = siguiente.TiempoLlegada;
                        }

                        continue;
                    }

                    break;
                }

                var actual = colaListos.Dequeue();

                if (actual.TiempoInicio < 0)
                {
                    actual.TiempoInicio = tiempoActual;
                    actual.TiempoRespuesta = tiempoActual - actual.TiempoLlegada;
                }

                var tiempoProximaLlegada = indiceLlegadas < totalProcesos
                    ? procesosOrdenados[indiceLlegadas].TiempoLlegada
                    : int.MaxValue;
                var tiempoHastaProximaLlegada = tiempoProximaLlegada - tiempoActual;
                var duracionEjecucion = actual.TiempoRestante;

                if (tiempoHastaProximaLlegada > 0)
                {
                    duracionEjecucion = Math.Min(duracionEjecucion, tiempoHastaProximaLlegada);
                }

                RegistrarPaso(actual, EstadoProceso.EnEjecucion, duracionEjecucion);

                tiempoActual += duracionEjecucion;
                actual.TiempoRestante -= duracionEjecucion;

                while (indiceLlegadas < totalProcesos && procesosOrdenados[indiceLlegadas].TiempoLlegada <= tiempoActual)
                {
                    var llegado = procesosOrdenados[indiceLlegadas];

                    if (llegado.TiempoRestante > 0)
                    {
                        RegistrarPaso(llegado, EstadoProceso.Listo);
                        colaListos.Enqueue(llegado, (llegado.TiempoRestante, llegado.TiempoLlegada, contadorSecuencia++));
                    }

                    indiceLlegadas++;
                }

                if (actual.TiempoRestante > 0)
                {
                    RegistrarPaso(actual, EstadoProceso.Listo);
                    colaListos.Enqueue(actual, (actual.TiempoRestante, actual.TiempoLlegada, contadorSecuencia++));
                }
                else
                {
                    actual.TiempoFin = tiempoActual;
                    actual.TiempoRetorno = actual.TiempoFin - actual.TiempoLlegada;
                    actual.TiempoEspera = actual.TiempoRetorno - actual.Duracion;
                    RegistrarPaso(actual, EstadoProceso.Terminado);
                }
            }

            foreach (var proceso in procesos)
            {
                if (proceso.TiempoInicio < 0)
                {
                    proceso.TiempoInicio = proceso.TiempoLlegada;
                }
            }
        }

        private void RegistrarPaso(Proceso? proceso, EstadoProceso estado, int duracion = 0)
        {
            if (proceso is not null)
            {
                proceso.Estado = estado;
            }

            pasos.Add(new PasoSimulacion(proceso, estado, duracion));
        }

        public IEnumerable<string[]> ObtenerResultadosFormateados()
        {
            Ejecutar();

            return procesos.Select(FormatearResultadoProceso);
        }

        public string[] FormatearResultadoProceso(Proceso proceso)
        {
            return new[]
            {
                proceso.Nombre,
                FormatearTiempo(proceso.TiempoLlegada),
                FormatearTiempo(proceso.Duracion),
                FormatearTiempo(proceso.TiempoInicio),
                FormatearTiempo(proceso.TiempoFin),
                FormatearTiempo(proceso.TiempoEspera),
                FormatearTiempo(proceso.TiempoRespuesta),
                FormatearTiempo(proceso.TiempoRetorno),
                FormatearEstado(proceso.Estado)
            };
        }

        public void SimularEjecucion(Action<Proceso, EstadoProceso>? notificarEstado, int milisegundosPorMinuto = MilisegundosPorMinutoPredeterminados)
        {
            PlanificarShortestRemainingTime();

            foreach (var paso in pasos)
            {
                if (paso.Proceso is not null)
                {
                    notificarEstado?.Invoke(paso.Proceso, paso.Estado);
                }

                if (paso.Duracion > 0 && milisegundosPorMinuto > 0)
                {
                    Thread.Sleep(paso.Duracion * milisegundosPorMinuto);
                }
            }
        }

        public Estadisticas CalcularEstadisticasRespuesta()
        {
            PlanificarShortestRemainingTime();
            return CalcularEstadisticas(procesos.Select(p => p.TiempoRespuesta));
        }

        public Estadisticas CalcularEstadisticasRetorno()
        {
            PlanificarShortestRemainingTime();
            return CalcularEstadisticas(procesos.Select(p => p.TiempoRetorno));
        }

        private static Estadisticas CalcularEstadisticas(IEnumerable<int> datos)
        {
            var lista = datos.ToList();

            if (lista.Count == 0)
            {
                return new Estadisticas(0, 0, 0, 0);
            }

            var minimo = lista.Min();
            var maximo = lista.Max();
            var promedio = lista.Average();
            var sumaCuadrados = lista.Sum(valor => Math.Pow(valor - promedio, 2));
            var desviacion = Math.Sqrt(sumaCuadrados / lista.Count);

            return new Estadisticas(minimo, maximo, promedio, desviacion);
        }

        public static string FormatearTiempo(int minutos)
        {
            if (minutos < 0)
            {
                return "--";
            }

            var tiempo = TimeSpan.FromMinutes(minutos);
            return $"{(int)tiempo.TotalHours:00}:{tiempo.Minutes:00}";
        }

        public static string FormatearEstado(EstadoProceso estado)
        {
            return estado switch
            {
                EstadoProceso.Bloqueado => "Bloqueado",
                EstadoProceso.Listo => "Listo",
                EstadoProceso.EnEjecucion => "En ejecución",
                EstadoProceso.Terminado => "Terminado",
                _ => estado.ToString() ?? string.Empty
            };
        }

        public static string FormatearValorEstadistico(double minutos)
        {
            return minutos.ToString("0.00", CultureInfo.InvariantCulture);
        }

        public record Estadisticas(double Minimo, double Maximo, double Promedio, double DesviacionEstandar);

        private sealed record PasoSimulacion(Proceso? Proceso, EstadoProceso Estado, int Duracion);
    }
}
