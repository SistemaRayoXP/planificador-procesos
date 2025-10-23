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
        private readonly Dictionary<TipoCola, ListView> _listasPorCola;
        private Thread? _hiloSimulacion;
        private const int MilisegundosPorMinuto = 1000;

        public MainForm()
        {
            InitializeComponent();

            _listasPorCola = new Dictionary<TipoCola, ListView>
            {
                { TipoCola.Fcfs, procesosFCFS },
                { TipoCola.RoundRobin, procesosRR },
                { TipoCola.Srt, procesosSRT }
            };

            var procesos = new List<Proceso>
            {
                // FCFS — Los responsables (más o menos)
                new("Compilador_legacy.exe", 0, 5, TipoCola.Fcfs),
                new("Analisis_financiero_2024.xlsx", 3, 4, TipoCola.Fcfs),
                new("Manual_admin_red_v5.pdf", 6, 2, TipoCola.Fcfs),
                new("Reporte_operaciones_final.docx", 9, 3, TipoCola.Fcfs),
                new("Plan_estrategico_cucei_2030.pptx", 1, 4, TipoCola.Fcfs),
                new("Inventario_componentes.csv", 2, 5, TipoCola.Fcfs),
                new("Informe_seguridad_redes.pdf", 4, 3, TipoCola.Fcfs),
                new("Tesis_en_proceso_v12_final_definitivo.docx", 7, 6, TipoCola.Fcfs),
                new("Comparativa_frameworks_backend.xlsx", 8, 4, TipoCola.Fcfs),
                new("Planificador_CPU_diagrama.drawio", 10, 5, TipoCola.Fcfs),
                new("Bitácora_servicio_social.txt", 11, 2, TipoCola.Fcfs),
                new("Registro_asistencia_lab.log", 13, 3, TipoCola.Fcfs),
                new("Manual_usuario_MI_VIAJE.pdf", 14, 4, TipoCola.Fcfs),
                new("Memoria_proyecto_modular.docx", 16, 5, TipoCola.Fcfs),
                new("Backup_documentos_serios.zip", 17, 6, TipoCola.Fcfs),

                // Round Robin — El carnaval del multitasking
                new("Respaldo_photos_marzo.zip", 1, 6, TipoCola.RoundRobin),
                new("Script_monitoreo.ps1", 4, 5, TipoCola.RoundRobin),
                new("Contenedor_pruebas.tar", 7, 4, TipoCola.RoundRobin),
                new("Cliente_chat_microservicio.log", 10, 3, TipoCola.RoundRobin),
                new("descarga_pelis_navidad_1080p.torrent", 2, 8, TipoCola.RoundRobin),
                new("actualizacion_sospechosa_driver_wifi.exe", 5, 7, TipoCola.RoundRobin),
                new("video_gato_con_traje.mp4", 8, 5, TipoCola.RoundRobin),
                new("Simulador_de_examen_CUCEI_v3.rar", 9, 4, TipoCola.RoundRobin),
                new("MiViaje_debug_apk.apk", 3, 6, TipoCola.RoundRobin),
                new("Juego_inacabado_gamejam.zip", 11, 5, TipoCola.RoundRobin),
                new("wallpapers_8K_no_preguntes.rar", 12, 6, TipoCola.RoundRobin),
                new("Instalador_office_2013_trial.exe", 13, 3, TipoCola.RoundRobin),
                new("Canciones_en_formato_raro.flac", 14, 4, TipoCola.RoundRobin),
                new("Proyecto_node_modules_backup.zip", 15, 7, TipoCola.RoundRobin),
                new("Driver_impresora_fantasma.pkg", 16, 5, TipoCola.RoundRobin),

                // SRT — Los intensos y existenciales
                new("Motor_inferencia_v2.bin", 2, 8, TipoCola.Srt),
                new("Dataset_sensores.csv", 5, 6, TipoCola.Srt),
                new("Worker_eventos.service", 6, 3, TipoCola.Srt),
                new("Hotfix_seguridad.patch", 8, 2, TipoCola.Srt),
                new("descarga_3GB_de_actualizaciones_innecesarias.iso", 1, 10, TipoCola.Srt),
                new("backup_chatGPT_logs_enero.json", 3, 9, TipoCola.Srt),
                new("instalador_de_java_otra_vez.exe", 4, 5, TipoCola.Srt),
                new("documental_tiburones_y_política.mkv", 7, 4, TipoCola.Srt),
                new("emulador_arcade_con_roms_secretas.zip", 9, 8, TipoCola.Srt),
                new("dataset_cats_vs_dogs_final_v3.zip", 10, 7, TipoCola.Srt),
                new("proyecto_inteligencia_artificial_definitivo.py", 11, 6, TipoCola.Srt),
                new("actualizacion_firmware_tostadora.bin", 12, 4, TipoCola.Srt),
                new("audio_experimento_432hz.wav", 13, 3, TipoCola.Srt),
                new("mapa_tren_ligero_ruta_oculta.kml", 15, 5, TipoCola.Srt),
                new("capturas_error_kernel_panic.zip", 16, 9, TipoCola.Srt)
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
            foreach (var lista in _listasPorCola.Values)
            {
                lista.BeginUpdate();
                lista.Items.Clear();
            }

            _itemsPorProceso.Clear();

            foreach (var proceso in _procesos)
            {
                var fila = _planificador.FormatearResultadoProceso(proceso);

                var item = new ListViewItem(fila)
                {
                    Checked = proceso.Estado == EstadoProceso.Terminado,
                    Tag = proceso
                };

                var lista = _listasPorCola[proceso.TipoCola];
                lista.Items.Add(item);
                _itemsPorProceso[proceso] = item;
            }

            foreach (var lista in _listasPorCola.Values)
            {
                lista.EndUpdate();
            }
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
