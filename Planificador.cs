using System.Collections.Generic;
using System.Linq;

namespace Planificador
{
    public class Planificador
    {
        private List<Proceso> procesos;

        public Planificador(List<Proceso> listaProcesos)
        {
            procesos = listaProcesos
                        .OrderBy(p => p.TiempoLlegada) // ordenar por llegada
                        .ToList();
        }

        public List<Proceso> Ejecutar()
        {
            int tiempoActual = 0;

            foreach (var p in procesos)
            {
                // Si el proceso llega después del tiempo actual, el CPU espera
                if (tiempoActual < p.TiempoLlegada)
                    tiempoActual = p.TiempoLlegada;

                p.TiempoInicio = tiempoActual;
                p.TiempoFin = tiempoActual + p.Duracion;
                p.TiempoEspera = p.TiempoInicio - p.TiempoLlegada;
                p.TiempoRetorno = p.TiempoFin - p.TiempoLlegada;

                tiempoActual = p.TiempoFin;
            }

            return procesos;
        }
    }
}