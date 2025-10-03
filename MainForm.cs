using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Planificador
{
    public partial class MainForm : Form
    {
        private readonly Planificador _planificador;

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
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            MostrarProcesos();
        }

        private void MostrarProcesos()
        {
            procesosListView.BeginUpdate();
            procesosListView.Items.Clear();

            foreach (var fila in _planificador.ObtenerResultadosFormateados())
            {
                var item = new ListViewItem(fila)
                {
                    Checked = true
                };

                procesosListView.Items.Add(item);
            }

            procesosListView.EndUpdate();
        }
    }
}
