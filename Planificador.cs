using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Planificador
{
    public class Planificador
    {
        private readonly List<Proceso> procesos;
        private const int MilisegundosPorMinutoPredeterminados = 1000;

        public Planificador(IEnumerable<Proceso> listaProcesos)
        {
            procesos = listaProcesos
                .OrderBy(p => p.TiempoLlegada)
                .ToList();
        }

        public IReadOnlyList<Proceso> Ejecutar()
        {
            int tiempoActual = 0;

            foreach (var proceso in procesos)
            {
                if (tiempoActual < proceso.TiempoLlegada)
                {
                    tiempoActual = proceso.TiempoLlegada;
                }

                proceso.TiempoInicio = tiempoActual;
                proceso.TiempoFin = tiempoActual + proceso.Duracion;
                proceso.TiempoEspera = proceso.TiempoInicio - proceso.TiempoLlegada;
                proceso.TiempoRetorno = proceso.TiempoFin - proceso.TiempoLlegada;

                tiempoActual = proceso.TiempoFin;
            }

            return procesos;
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
                FormatearTiempo(proceso.TiempoRetorno)
            };
        }

        public void SimularEjecucion(Action<Proceso>? alIniciar, Action<Proceso>? alFinalizar, int milisegundosPorMinuto = MilisegundosPorMinutoPredeterminados)
        {
            Ejecutar();

            int tiempoActual = 0;

            foreach (var proceso in procesos)
            {
                if (tiempoActual < proceso.TiempoLlegada)
                {
                    var espera = (proceso.TiempoLlegada - tiempoActual) * milisegundosPorMinuto;

                    if (espera > 0)
                    {
                        Thread.Sleep(espera);
                    }

                    tiempoActual = proceso.TiempoLlegada;
                }

                alIniciar?.Invoke(proceso);

                var duracion = proceso.Duracion * milisegundosPorMinuto;

                if (duracion > 0)
                {
                    Thread.Sleep(duracion);
                }

                tiempoActual += proceso.Duracion;

                alFinalizar?.Invoke(proceso);
            }
        }

        public static string FormatearTiempo(int minutos)
        {
            var tiempo = TimeSpan.FromMinutes(minutos);
            return $"{(int)tiempo.TotalHours:00}:{tiempo.Minutes:00}";
        }
    }
}
