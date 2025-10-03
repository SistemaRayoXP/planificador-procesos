using System;
using System.Collections.Generic;
using System.Linq;

namespace Planificador
{
    public class Planificador
    {
        private readonly List<Proceso> procesos;

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

            return procesos.Select(proceso => new[]
            {
                proceso.Nombre,
                FormatearTiempo(proceso.TiempoLlegada),
                FormatearTiempo(proceso.Duracion),
                FormatearTiempo(proceso.TiempoInicio),
                FormatearTiempo(proceso.TiempoFin),
                FormatearTiempo(proceso.TiempoEspera),
                FormatearTiempo(proceso.TiempoRetorno)
            });
        }

        private static string FormatearTiempo(int minutos)
        {
            var tiempo = TimeSpan.FromMinutes(minutos);
            return $"{(int)tiempo.TotalHours:00}:{tiempo.Minutes:00}";
        }
    }
}
