using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Planificador
{
    public partial class MainForm : Form
    {
        private readonly Planificador _planificador;
        private readonly IReadOnlyList<Proceso> _procesos;
        private readonly Dictionary<Proceso, ListViewItem> _itemsPorProceso = new();
        private Thread? _hiloSimulacion;
        private const int MilisegundosPorMinuto = 1000;

        public MainForm()
        {
            InitializeComponent();

            var procesos = new List<Proceso>
            {
                new("Compilador_legacy.exe", 0, 5, TipoCola.Fcfs),
                new("Analisis_financiero_2024.xlsx", 3, 4, TipoCola.Fcfs),
                new("Manual_admin_red_v5.pdf", 6, 2, TipoCola.Fcfs),
                new("Reporte_operaciones_final.docx", 9, 3, TipoCola.Fcfs),
                new("Respaldo_photos_marzo.zip", 1, 6, TipoCola.RoundRobin),
                new("Script_monitoreo.ps1", 4, 5, TipoCola.RoundRobin),
                new("Contenedor_pruebas.tar", 7, 4, TipoCola.RoundRobin),
                new("Cliente_chat_microservicio.log", 10, 3, TipoCola.RoundRobin),
                new("Motor_inferencia_v2.bin", 2, 8, TipoCola.Srt),
                new("Dataset_sensores.csv", 5, 6, TipoCola.Srt),
                new("Worker_eventos.service", 6, 3, TipoCola.Srt),
                new("Hotfix_seguridad.patch", 8, 2, TipoCola.Srt)
            };
            _planificador = new Planificador(procesos);
            _procesos = _planificador.Ejecutar();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            MostrarProcesos();
            MostrarEstadisticas();
            IniciarSimulacion();
        }

        private void MostrarProcesos()
        {
            procesosFCFS.BeginUpdate();
            procesosFCFS.Items.Clear();
            _itemsPorProceso.Clear();

            foreach (var proceso in _procesos)
            {
                var fila = _planificador.FormatearResultadoProceso(proceso);

                var item = new ListViewItem(fila)
                {
                    Checked = proceso.Estado == EstadoProceso.Terminado,
                    Tag = proceso
                };

                procesosFCFS.Items.Add(item);
                _itemsPorProceso[proceso] = item;
            }

            procesosFCFS.EndUpdate();
        }

        private void MostrarEstadisticas()
        {
            var estadisticasRespuesta = _planificador.CalcularEstadisticasRespuesta();
            var estadisticasRetorno = _planificador.CalcularEstadisticasRetorno();

            estadisticasListView.BeginUpdate();
            estadisticasListView.Items.Clear();

            estadisticasListView.Items.Add(CrearItemEstadistica("Tiempo de respuesta", estadisticasRespuesta));
            estadisticasListView.Items.Add(CrearItemEstadistica("Tiempo de retorno", estadisticasRetorno));

            estadisticasListView.EndUpdate();
        }

        private static ListViewItem CrearItemEstadistica(string descripcion, Planificador.Estadisticas estadisticas)
        {
            return new ListViewItem(new[]
            {
                descripcion,
                Planificador.FormatearValorEstadistico(estadisticas.Minimo),
                Planificador.FormatearValorEstadistico(estadisticas.Maximo),
                Planificador.FormatearValorEstadistico(estadisticas.Promedio),
                Planificador.FormatearValorEstadistico(estadisticas.DesviacionEstandar)
            });
        }

        private void IniciarSimulacion()
        {
            _hiloSimulacion = new Thread(() =>
            {
                _planificador.SimularEjecucion(
                    ActualizarEstadoProceso,
                    MilisegundosPorMinuto);
            })
            {
                IsBackground = true
            };

            _hiloSimulacion.Start();
        }

        private void ActualizarEstadoProceso(Proceso proceso, EstadoProceso estado)
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ActualizarEstadoProceso(proceso, estado)));
                return;
            }

            if (!_itemsPorProceso.TryGetValue(proceso, out var item))
            {
                return;
            }

            item.Checked = estado == EstadoProceso.Terminado;
            item.SubItems[9].Text = Planificador.FormatearEstado(estado);

            switch (estado)
            {
                case EstadoProceso.EnEjecucion:
                    item.SubItems[0].Text = $"{proceso.Nombre} (En ejecución)";
                    break;
                case EstadoProceso.Listo:
                    item.SubItems[0].Text = $"{proceso.Nombre} (Listo)";
                    break;
                case EstadoProceso.Bloqueado:
                    item.SubItems[0].Text = $"{proceso.Nombre} (Bloqueado)";
                    break;
                default:
                    item.SubItems[0].Text = proceso.Nombre;
                    break;
            }

            if (estado == EstadoProceso.Terminado)
            {
                item.SubItems[4].Text = Planificador.FormatearTiempo(proceso.TiempoInicio);
                item.SubItems[5].Text = Planificador.FormatearTiempo(proceso.TiempoFin);
                item.SubItems[6].Text = Planificador.FormatearTiempo(proceso.TiempoEspera);
                item.SubItems[7].Text = Planificador.FormatearTiempo(proceso.TiempoRespuesta);
                item.SubItems[8].Text = Planificador.FormatearTiempo(proceso.TiempoRetorno);
                item.SubItems[0].Text = proceso.Nombre;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Planificador de procesos de Cola Multi Nivel (CoMuNi)", "Planificador CoMuNi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
