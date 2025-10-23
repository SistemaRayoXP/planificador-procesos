namespace Planificador
{
    public class Proceso
    {
        public string Nombre { get; set; }
        public int TiempoLlegada { get; set; }   // instante en que llega
        public int Duracion { get; set; }        // cuanto tiempo requiere

        // Estos los calculara el planificador
        public int TiempoInicio { get; set; }
        public int TiempoFin { get; set; }
        public int TiempoEspera { get; set; }
        public int TiempoRetorno { get; set; }
        public int TiempoRespuesta { get; set; }
        public int TiempoRestante { get; set; }
        public EstadoProceso Estado { get; set; } = EstadoProceso.Bloqueado;
        public TipoCola TipoCola { get; set; }

        public Proceso(string nombre, int llegada, int duracion, TipoCola tipoCola)
        {
            Nombre = nombre;
            TiempoLlegada = llegada;
            Duracion = duracion;
            TipoCola = tipoCola;
        }
    }
}
