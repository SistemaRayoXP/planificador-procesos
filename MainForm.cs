using System.Collections.Generic;

namespace Planificador
{
    public partial class MainForm : Form
    {
        bool initialized = false;
        bool sentFromApplication = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (initialized && !sentFromApplication)
            {
                e.NewValue = e.CurrentValue;
                sentFromApplication = false;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            initialized = true;
            CargarProcesos();  // 👉 al mostrarse el form, carga los procesos
        }

        private void CargarProcesos()
        {
            // 🔹 Aquí defines tus procesos de ejemplo
            var lista = new List<Proceso>
            {
                new Proceso("Descarga 1", 0, 5),
                new Proceso("Descarga 2", 3, 2),
                new Proceso("Descarga 3", 5, 4)
            };

            // 🔹 Pasar la lista al planificador
            var planificador = new Planificador(lista);
            var resultado = planificador.Ejecutar();

            // 🔹 Mostrar resultados en el ListView
            listView1.Items.Clear();
            foreach (var p in resultado)
            {
                var item = new ListViewItem(new string[]
                {
                    p.Nombre,
                    p.TiempoLlegada.ToString(),
                    p.Duracion.ToString(),
                    p.TiempoInicio.ToString(),
                    p.TiempoFin.ToString(),
                    p.TiempoEspera.ToString(),
                    p.TiempoRetorno.ToString()
                });
                listView1.Items.Add(item);
            }
        }
    }
}
