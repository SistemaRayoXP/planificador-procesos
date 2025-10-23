namespace Planificador
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            procesosFCFS = new ListView();
            processHeader = new ColumnHeader();
            queueHeader = new ColumnHeader();
            arrivalHeader = new ColumnHeader();
            durationHeader = new ColumnHeader();
            startTimeHeader = new ColumnHeader();
            endTimeHeader = new ColumnHeader();
            waitTimeHeader = new ColumnHeader();
            responseTimeHeader = new ColumnHeader();
            returnTimeHeader = new ColumnHeader();
            stateHeader = new ColumnHeader();
            estadisticasListView = new ListView();
            metricHeader = new ColumnHeader();
            minHeader = new ColumnHeader();
            maxHeader = new ColumnHeader();
            avgHeader = new ColumnHeader();
            stdDevHeader = new ColumnHeader();
            procesosRR = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            procesosSRT = new ListView();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            columnHeader17 = new ColumnHeader();
            columnHeader18 = new ColumnHeader();
            columnHeader19 = new ColumnHeader();
            columnHeader20 = new ColumnHeader();
            tableLayoutPanel3 = new TableLayoutPanel();
            lbl_fcfs = new Label();
            lbl_rr = new Label();
            lbl_srt = new Label();
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // procesosFCFS
            // 
            procesosFCFS.BorderStyle = BorderStyle.FixedSingle;
            procesosFCFS.CheckBoxes = true;
            procesosFCFS.Columns.AddRange(new ColumnHeader[] { processHeader, queueHeader, arrivalHeader, durationHeader, startTimeHeader, endTimeHeader, waitTimeHeader, responseTimeHeader, returnTimeHeader, stateHeader });
            procesosFCFS.Dock = DockStyle.Fill;
            procesosFCFS.FullRowSelect = true;
            procesosFCFS.GridLines = true;
            procesosFCFS.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            procesosFCFS.Location = new Point(3, 2);
            procesosFCFS.Margin = new Padding(3, 2, 3, 2);
            procesosFCFS.MultiSelect = false;
            procesosFCFS.Name = "procesosFCFS";
            procesosFCFS.ShowGroups = false;
            procesosFCFS.Size = new Size(243, 131);
            procesosFCFS.TabIndex = 0;
            procesosFCFS.UseCompatibleStateImageBehavior = false;
            procesosFCFS.View = View.Details;
            // 
            // processHeader
            // 
            processHeader.Text = "Proceso";
            processHeader.Width = 220;
            // 
            // queueHeader
            // 
            queueHeader.Text = "Cola";
            queueHeader.Width = 120;
            // 
            // arrivalHeader
            // 
            arrivalHeader.Text = "Llegada";
            arrivalHeader.Width = 90;
            // 
            // durationHeader
            // 
            durationHeader.Text = "Duración";
            durationHeader.Width = 90;
            // 
            // startTimeHeader
            // 
            startTimeHeader.Text = "Inicio";
            startTimeHeader.Width = 90;
            // 
            // endTimeHeader
            // 
            endTimeHeader.Text = "Fin";
            endTimeHeader.Width = 90;
            // 
            // waitTimeHeader
            // 
            waitTimeHeader.Text = "Espera";
            waitTimeHeader.Width = 90;
            // 
            // responseTimeHeader
            // 
            responseTimeHeader.Text = "Respuesta";
            responseTimeHeader.Width = 100;
            // 
            // returnTimeHeader
            // 
            returnTimeHeader.Text = "Retorno";
            returnTimeHeader.Width = 90;
            // 
            // stateHeader
            // 
            stateHeader.Text = "Estado";
            stateHeader.Width = 120;
            // 
            // estadisticasListView
            // 
            estadisticasListView.BorderStyle = BorderStyle.FixedSingle;
            estadisticasListView.Columns.AddRange(new ColumnHeader[] { metricHeader, minHeader, maxHeader, avgHeader, stdDevHeader });
            estadisticasListView.Dock = DockStyle.Fill;
            estadisticasListView.FullRowSelect = true;
            estadisticasListView.GridLines = true;
            estadisticasListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            estadisticasListView.Location = new Point(3, 183);
            estadisticasListView.Margin = new Padding(3, 2, 3, 2);
            estadisticasListView.MultiSelect = false;
            estadisticasListView.Name = "estadisticasListView";
            estadisticasListView.ShowGroups = false;
            estadisticasListView.Size = new Size(749, 138);
            estadisticasListView.TabIndex = 1;
            estadisticasListView.UseCompatibleStateImageBehavior = false;
            estadisticasListView.View = View.Details;
            // 
            // metricHeader
            // 
            metricHeader.Text = "Métrica";
            metricHeader.Width = 180;
            // 
            // minHeader
            // 
            minHeader.Text = "Mínimo (min)";
            minHeader.Width = 130;
            // 
            // maxHeader
            // 
            maxHeader.Text = "Máximo (min)";
            maxHeader.Width = 130;
            // 
            // avgHeader
            // 
            avgHeader.Text = "Promedio (min)";
            avgHeader.Width = 150;
            // 
            // stdDevHeader
            // 
            stdDevHeader.Text = "Desv. estándar (min)";
            stdDevHeader.Width = 180;
            // 
            // procesosRR
            // 
            procesosRR.BorderStyle = BorderStyle.FixedSingle;
            procesosRR.CheckBoxes = true;
            procesosRR.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            procesosRR.Dock = DockStyle.Fill;
            procesosRR.FullRowSelect = true;
            procesosRR.GridLines = true;
            procesosRR.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            procesosRR.Location = new Point(252, 2);
            procesosRR.Margin = new Padding(3, 2, 3, 2);
            procesosRR.MultiSelect = false;
            procesosRR.Name = "procesosRR";
            procesosRR.ShowGroups = false;
            procesosRR.Size = new Size(243, 131);
            procesosRR.TabIndex = 2;
            procesosRR.UseCompatibleStateImageBehavior = false;
            procesosRR.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Proceso";
            columnHeader1.Width = 220;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Cola";
            columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Llegada";
            columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Duración";
            columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Inicio";
            columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Fin";
            columnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Espera";
            columnHeader7.Width = 90;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Respuesta";
            columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Retorno";
            columnHeader9.Width = 90;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Estado";
            columnHeader10.Width = 120;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(estadisticasListView, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(755, 323);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(procesosSRT, 2, 0);
            tableLayoutPanel2.Controls.Add(procesosRR, 1, 0);
            tableLayoutPanel2.Controls.Add(procesosFCFS, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 43);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(749, 135);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // procesosSRT
            // 
            procesosSRT.BorderStyle = BorderStyle.FixedSingle;
            procesosSRT.CheckBoxes = true;
            procesosSRT.Columns.AddRange(new ColumnHeader[] { columnHeader11, columnHeader12, columnHeader13, columnHeader14, columnHeader15, columnHeader16, columnHeader17, columnHeader18, columnHeader19, columnHeader20 });
            procesosSRT.Dock = DockStyle.Fill;
            procesosSRT.FullRowSelect = true;
            procesosSRT.GridLines = true;
            procesosSRT.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            procesosSRT.Location = new Point(501, 2);
            procesosSRT.Margin = new Padding(3, 2, 3, 2);
            procesosSRT.MultiSelect = false;
            procesosSRT.Name = "procesosSRT";
            procesosSRT.ShowGroups = false;
            procesosSRT.Size = new Size(245, 131);
            procesosSRT.TabIndex = 3;
            procesosSRT.UseCompatibleStateImageBehavior = false;
            procesosSRT.View = View.Details;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Proceso";
            columnHeader11.Width = 220;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Cola";
            columnHeader12.Width = 120;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "Llegada";
            columnHeader13.Width = 90;
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "Duración";
            columnHeader14.Width = 90;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "Inicio";
            columnHeader15.Width = 90;
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "Fin";
            columnHeader16.Width = 90;
            // 
            // columnHeader17
            // 
            columnHeader17.Text = "Espera";
            columnHeader17.Width = 90;
            // 
            // columnHeader18
            // 
            columnHeader18.Text = "Respuesta";
            columnHeader18.Width = 100;
            // 
            // columnHeader19
            // 
            columnHeader19.Text = "Retorno";
            columnHeader19.Width = 90;
            // 
            // columnHeader20
            // 
            columnHeader20.Text = "Estado";
            columnHeader20.Width = 120;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Controls.Add(lbl_fcfs, 0, 0);
            tableLayoutPanel3.Controls.Add(lbl_rr, 1, 0);
            tableLayoutPanel3.Controls.Add(lbl_srt, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(749, 34);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // lbl_fcfs
            // 
            lbl_fcfs.AutoSize = true;
            lbl_fcfs.Dock = DockStyle.Fill;
            lbl_fcfs.Location = new Point(3, 0);
            lbl_fcfs.Name = "lbl_fcfs";
            lbl_fcfs.Size = new Size(243, 34);
            lbl_fcfs.TabIndex = 0;
            lbl_fcfs.Text = "PEPSI";
            lbl_fcfs.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_rr
            // 
            lbl_rr.AutoSize = true;
            lbl_rr.Dock = DockStyle.Fill;
            lbl_rr.Location = new Point(252, 0);
            lbl_rr.Name = "lbl_rr";
            lbl_rr.Size = new Size(243, 34);
            lbl_rr.TabIndex = 1;
            lbl_rr.Text = "Ronda Redonda";
            lbl_rr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_srt
            // 
            lbl_srt.AutoSize = true;
            lbl_srt.Dock = DockStyle.Fill;
            lbl_srt.Location = new Point(501, 0);
            lbl_srt.Name = "lbl_srt";
            lbl_srt.Size = new Size(245, 34);
            lbl_srt.TabIndex = 2;
            lbl_srt.Text = "MeTRo";
            lbl_srt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.BackgroundImageLayout = ImageLayout.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(755, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuBar";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(180, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { acercaDeToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 20);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(180, 22);
            acercaDeToolStripMenuItem.Text = "Acerca de";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(755, 347);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Planificador de procesos CoMuNi";
            Shown += MainForm_Shown;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ListView procesosFCFS;
        private System.Windows.Forms.ColumnHeader processHeader;
        private System.Windows.Forms.ColumnHeader queueHeader;
        private System.Windows.Forms.ColumnHeader arrivalHeader;
        private System.Windows.Forms.ColumnHeader durationHeader;
        private System.Windows.Forms.ColumnHeader startTimeHeader;
        private System.Windows.Forms.ColumnHeader endTimeHeader;
        private System.Windows.Forms.ColumnHeader waitTimeHeader;
        private System.Windows.Forms.ColumnHeader responseTimeHeader;
        private System.Windows.Forms.ColumnHeader returnTimeHeader;
        private System.Windows.Forms.ColumnHeader stateHeader;
        private System.Windows.Forms.ListView estadisticasListView;
        private System.Windows.Forms.ColumnHeader metricHeader;
        private System.Windows.Forms.ColumnHeader minHeader;
        private System.Windows.Forms.ColumnHeader maxHeader;
        private System.Windows.Forms.ColumnHeader avgHeader;
        private System.Windows.Forms.ColumnHeader stdDevHeader;
        private ListView procesosRR;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ListView procesosSRT;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private TableLayoutPanel tableLayoutPanel3;
        private Label lbl_fcfs;
        private Label lbl_rr;
        private Label lbl_srt;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}
