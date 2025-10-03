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
