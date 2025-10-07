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
        private const int Quantum = 3;

        public MainForm()
        {
            InitializeComponent();

            var procesos = new List<Proceso>
            {
                new("WXPVOLSP3.iso", 0, 5),
                new("Tu_tio_cuando_va_al_mar.mp4", 2, 3),
                new("Shrek_2_LATINO_FINALFINAL.avi", 3, 7),
                new("Tarea_matematicas_definitiva_v3.pdf", 4, 2),
                new("Naruto_episodio_134_subs_raros.mkv", 5, 6),
                new("Soundtrack_El_Chavo_en_8D.mp3", 6, 4),
                new("VirusGratisNoEsVirus.rar", 7, 3),
                new("FotoCarnet_con_bigote_editado.png", 8, 2),
                new("Manual_QuantumComputing_para_principiantes.docx", 9, 5),
                new("backup_celular_mi_ex_2015.zip", 10, 9),
                new("Presentacion_Final_DE_VERDAD.pptx", 11, 4)
            };
            _planificador = new Planificador(procesos, Quantum);
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
            procesosListView.BeginUpdate();
            procesosListView.Items.Clear();
            _itemsPorProceso.Clear();

            foreach (var proceso in _procesos)
            {
                var fila = _planificador.FormatearResultadoProceso(proceso);

                var item = new ListViewItem(fila)
                {
                    Checked = proceso.Estado == EstadoProceso.Terminado,
                    Tag = proceso
                };

                procesosListView.Items.Add(item);
                _itemsPorProceso[proceso] = item;
            }

            procesosListView.EndUpdate();
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
            item.SubItems[8].Text = Planificador.FormatearEstado(estado);

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
                item.SubItems[3].Text = Planificador.FormatearTiempo(proceso.TiempoInicio);
                item.SubItems[4].Text = Planificador.FormatearTiempo(proceso.TiempoFin);
                item.SubItems[5].Text = Planificador.FormatearTiempo(proceso.TiempoEspera);
                item.SubItems[6].Text = Planificador.FormatearTiempo(proceso.TiempoRespuesta);
                item.SubItems[7].Text = Planificador.FormatearTiempo(proceso.TiempoRetorno);
                item.SubItems[0].Text = proceso.Nombre;
            }
        }
    }
}
