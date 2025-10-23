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
        private readonly Dictionary<TipoCola, List<PasoSimulacion>> pasosPorCola = new();
        private const int MilisegundosPorMinutoPredeterminados = 1000;
        private const int QuantumRoundRobin = 2;

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
            PlanificarMultiNivel();
            return procesos;
        }

        private void PlanificarMultiNivel()
        {
            pasosPorCola.Clear();

            foreach (var tipo in Enum.GetValues<TipoCola>())
            {
                pasosPorCola[tipo] = new List<PasoSimulacion>();
            }

            foreach (var proceso in procesos)
            {
                proceso.TiempoInicio = -1;
                proceso.TiempoFin = 0;
                proceso.TiempoEspera = 0;
                proceso.TiempoRetorno = 0;
                proceso.TiempoRespuesta = 0;
                proceso.TiempoRestante = proceso.Duracion;
                proceso.Estado = EstadoProceso.Bloqueado;
                RegistrarPaso(proceso.TipoCola, proceso, EstadoProceso.Bloqueado);
            }

            PlanificarFirstComeFirstServed(procesos.Where(p => p.TipoCola == TipoCola.Fcfs));
            PlanificarRoundRobin(procesos.Where(p => p.TipoCola == TipoCola.RoundRobin));
            PlanificarShortestRemainingTime(procesos.Where(p => p.TipoCola == TipoCola.Srt));
        }

        private void PlanificarFirstComeFirstServed(IEnumerable<Proceso> procesosFcfs)
        {
            var lista = procesosFcfs
                .OrderBy(p => p.TiempoLlegada)
                .ToList();

            if (lista.Count == 0)
            {
                return;
            }

            var tiempoActual = lista.Min(p => p.TiempoLlegada);

            foreach (var proceso in lista)
            {
                if (tiempoActual < proceso.TiempoLlegada)
                {
                    var tiempoInactivo = proceso.TiempoLlegada - tiempoActual;
                    RegistrarPaso(TipoCola.Fcfs, null, EstadoProceso.Bloqueado, tiempoInactivo);
                    tiempoActual = proceso.TiempoLlegada;
                }

                RegistrarPaso(TipoCola.Fcfs, proceso, EstadoProceso.Listo);

                proceso.TiempoInicio = tiempoActual;
                proceso.TiempoRespuesta = tiempoActual - proceso.TiempoLlegada;
                proceso.TiempoEspera = tiempoActual - proceso.TiempoLlegada;

                RegistrarPaso(TipoCola.Fcfs, proceso, EstadoProceso.EnEjecucion, proceso.Duracion);

                tiempoActual += proceso.Duracion;
                proceso.TiempoFin = tiempoActual;
                proceso.TiempoRetorno = proceso.TiempoFin - proceso.TiempoLlegada;
                proceso.TiempoRestante = 0;

                RegistrarPaso(TipoCola.Fcfs, proceso, EstadoProceso.Terminado);
            }
        }

        private void PlanificarRoundRobin(IEnumerable<Proceso> procesosRoundRobin)
        {
            var lista = procesosRoundRobin
                .OrderBy(p => p.TiempoLlegada)
                .ToList();

            if (lista.Count == 0)
            {
                return;
            }

            var colaListos = new Queue<Proceso>();
            var tiempoActual = lista.Min(p => p.TiempoLlegada);
            var indiceLlegadas = 0;

            while (colaListos.Count > 0 || indiceLlegadas < lista.Count)
            {
                while (indiceLlegadas < lista.Count && lista[indiceLlegadas].TiempoLlegada <= tiempoActual)
                {
                    var llegado = lista[indiceLlegadas++];
                    RegistrarPaso(TipoCola.RoundRobin, llegado, EstadoProceso.Listo);
                    colaListos.Enqueue(llegado);
                }

                if (colaListos.Count == 0)
                {
                    if (indiceLlegadas < lista.Count)
                    {
                        var siguiente = lista[indiceLlegadas];
                        if (siguiente.TiempoLlegada > tiempoActual)
                        {
                            var tiempoInactivo = siguiente.TiempoLlegada - tiempoActual;
                            RegistrarPaso(TipoCola.RoundRobin, null, EstadoProceso.Bloqueado, tiempoInactivo);
                            tiempoActual = siguiente.TiempoLlegada;
                        }
                    }

                    continue;
                }

                var actual = colaListos.Dequeue();

                if (actual.TiempoInicio < 0)
                {
                    actual.TiempoInicio = tiempoActual;
                    actual.TiempoRespuesta = tiempoActual - actual.TiempoLlegada;
                }

                var duracionEjecucion = Math.Min(actual.TiempoRestante, QuantumRoundRobin);
                RegistrarPaso(TipoCola.RoundRobin, actual, EstadoProceso.EnEjecucion, duracionEjecucion);

                tiempoActual += duracionEjecucion;
                actual.TiempoRestante -= duracionEjecucion;

                while (indiceLlegadas < lista.Count && lista[indiceLlegadas].TiempoLlegada <= tiempoActual)
                {
                    var llegado = lista[indiceLlegadas++];
                    RegistrarPaso(TipoCola.RoundRobin, llegado, EstadoProceso.Listo);
                    colaListos.Enqueue(llegado);
                }

                if (actual.TiempoRestante > 0)
                {
                    RegistrarPaso(TipoCola.RoundRobin, actual, EstadoProceso.Listo);
                    colaListos.Enqueue(actual);
                }
                else
                {
                    actual.TiempoFin = tiempoActual;
                    actual.TiempoRetorno = actual.TiempoFin - actual.TiempoLlegada;
                    actual.TiempoEspera = actual.TiempoRetorno - actual.Duracion;
                    actual.TiempoRestante = 0;
                    RegistrarPaso(TipoCola.RoundRobin, actual, EstadoProceso.Terminado);
                }
            }
        }

        private void PlanificarShortestRemainingTime(IEnumerable<Proceso> procesosSrt)
        {
            var lista = procesosSrt
                .OrderBy(p => p.TiempoLlegada)
                .ToList();

            if (lista.Count == 0)
            {
                return;
            }

            var colaListos = new PriorityQueue<Proceso, (int TiempoRestante, int TiempoLlegada, int Secuencia)>();
            var totalProcesos = lista.Count;
            var indiceLlegadas = 0;
            var tiempoActual = lista.Min(p => p.TiempoLlegada);
            var contadorSecuencia = 0;

            while (colaListos.Count > 0 || indiceLlegadas < totalProcesos)
            {
                while (indiceLlegadas < totalProcesos && lista[indiceLlegadas].TiempoLlegada <= tiempoActual)
                {
                    var llegado = lista[indiceLlegadas];

                    if (llegado.TiempoRestante > 0)
                    {
                        RegistrarPaso(TipoCola.Srt, llegado, EstadoProceso.Listo);
                        colaListos.Enqueue(llegado, (llegado.TiempoRestante, llegado.TiempoLlegada, contadorSecuencia++));
                    }

                    indiceLlegadas++;
                }

                if (colaListos.Count == 0)
                {
                    if (indiceLlegadas < totalProcesos)
                    {
                        var siguiente = lista[indiceLlegadas];

                        if (siguiente.TiempoLlegada > tiempoActual)
                        {
                            var tiempoInactivo = siguiente.TiempoLlegada - tiempoActual;
                            RegistrarPaso(TipoCola.Srt, null, EstadoProceso.Bloqueado, tiempoInactivo);
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
                    ? lista[indiceLlegadas].TiempoLlegada
                    : int.MaxValue;
                var tiempoHastaProximaLlegada = tiempoProximaLlegada - tiempoActual;
                var duracionEjecucion = actual.TiempoRestante;

                if (tiempoHastaProximaLlegada > 0)
                {
                    duracionEjecucion = Math.Min(duracionEjecucion, tiempoHastaProximaLlegada);
                }

                RegistrarPaso(TipoCola.Srt, actual, EstadoProceso.EnEjecucion, duracionEjecucion);

                tiempoActual += duracionEjecucion;
                actual.TiempoRestante -= duracionEjecucion;

                while (indiceLlegadas < totalProcesos && lista[indiceLlegadas].TiempoLlegada <= tiempoActual)
                {
                    var llegado = lista[indiceLlegadas];

                    if (llegado.TiempoRestante > 0)
                    {
                        RegistrarPaso(TipoCola.Srt, llegado, EstadoProceso.Listo);
                        colaListos.Enqueue(llegado, (llegado.TiempoRestante, llegado.TiempoLlegada, contadorSecuencia++));
                    }

                    indiceLlegadas++;
                }

                if (actual.TiempoRestante > 0)
                {
                    RegistrarPaso(TipoCola.Srt, actual, EstadoProceso.Listo);
                    colaListos.Enqueue(actual, (actual.TiempoRestante, actual.TiempoLlegada, contadorSecuencia++));
                }
                else
                {
                    actual.TiempoFin = tiempoActual;
                    actual.TiempoRetorno = actual.TiempoFin - actual.TiempoLlegada;
                    actual.TiempoEspera = actual.TiempoRetorno - actual.Duracion;
                    actual.TiempoRestante = 0;
                    RegistrarPaso(TipoCola.Srt, actual, EstadoProceso.Terminado);
                }
            }

            foreach (var proceso in lista)
            {
                if (proceso.TiempoInicio < 0)
                {
                    proceso.TiempoInicio = proceso.TiempoLlegada;
                }
            }
        }

        private void RegistrarPaso(TipoCola tipoCola, Proceso? proceso, EstadoProceso estado, int duracion = 0)
        {
            if (proceso is not null)
            {
                proceso.Estado = estado;
            }

            if (!pasosPorCola.TryGetValue(tipoCola, out var listaPasos))
            {
                listaPasos = new List<PasoSimulacion>();
                pasosPorCola[tipoCola] = listaPasos;
            }

            listaPasos.Add(new PasoSimulacion(proceso, estado, duracion));
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
                FormatearTipoCola(proceso.TipoCola),
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
            PlanificarMultiNivel();

            var hilos = new List<Thread>();

            foreach (var (tipo, pasos) in pasosPorCola)
            {
                if (pasos.Count == 0)
                {
                    continue;
                }

                var hilo = new Thread(() =>
                {
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
                })
                {
                    IsBackground = true,
                    Name = $"Simulacion_{tipo}"
                };

                hilos.Add(hilo);
                hilo.Start();
            }

            foreach (var hilo in hilos)
            {
                hilo.Join();
            }
        }

        public Estadisticas CalcularEstadisticasRespuesta()
        {
            PlanificarMultiNivel();
            return CalcularEstadisticas(procesos.Select(p => p.TiempoRespuesta));
        }

        public Estadisticas CalcularEstadisticasRetorno()
        {
            PlanificarMultiNivel();
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

        public static string FormatearTipoCola(TipoCola tipoCola)
        {
            return tipoCola switch
            {
                TipoCola.Fcfs => "FCFS",
                TipoCola.RoundRobin => "Round Robin",
                TipoCola.Srt => "SRT",
                _ => tipoCola.ToString() ?? string.Empty
            };
        }

        public record Estadisticas(double Minimo, double Maximo, double Promedio, double DesviacionEstandar);

        private sealed record PasoSimulacion(Proceso? Proceso, EstadoProceso Estado, int Duracion);
    }
}
