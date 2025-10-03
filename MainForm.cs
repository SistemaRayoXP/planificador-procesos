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
                new("Descarga 1", 0, 5),
                new("Descarga 2", 3, 2),
                new("Descarga 3", 5, 4)
            };
            _planificador = new Planificador(procesos);
            _procesos = _planificador.Ejecutar();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            MostrarProcesos();
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
                    Checked = false,
                    Tag = proceso
                };

                procesosListView.Items.Add(item);
                _itemsPorProceso[proceso] = item;
            }

            procesosListView.EndUpdate();
        }

        private void IniciarSimulacion()
        {
            _hiloSimulacion = new Thread(() =>
            {
                _planificador.SimularEjecucion(
                    proceso => ActualizarEstadoProceso(proceso, false),
                    proceso => ActualizarEstadoProceso(proceso, true),
                    MilisegundosPorMinuto);
            })
            {
                IsBackground = true
            };

            _hiloSimulacion.Start();
        }

        private void ActualizarEstadoProceso(Proceso proceso, bool completado)
        {
            if (IsDisposed)
            {
                return;
            }

            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ActualizarEstadoProceso(proceso, completado)));
                return;
            }

            if (!_itemsPorProceso.TryGetValue(proceso, out var item))
            {
                return;
            }

            item.Checked = completado;

            if (completado)
            {
                item.SubItems[0].Text = proceso.Nombre;
            }
            else
            {
                item.SubItems[0].Text = $"{proceso.Nombre} (En ejecución)";
            }
        }
    }
}
