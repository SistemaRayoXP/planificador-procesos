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
            this.procesosListView = new System.Windows.Forms.ListView();
            this.processHeader = new System.Windows.Forms.ColumnHeader();
            this.arrivalHeader = new System.Windows.Forms.ColumnHeader();
            this.durationHeader = new System.Windows.Forms.ColumnHeader();
            this.startTimeHeader = new System.Windows.Forms.ColumnHeader();
            this.endTimeHeader = new System.Windows.Forms.ColumnHeader();
            this.waitTimeHeader = new System.Windows.Forms.ColumnHeader();
            this.responseTimeHeader = new System.Windows.Forms.ColumnHeader();
            this.returnTimeHeader = new System.Windows.Forms.ColumnHeader();
            this.stateHeader = new System.Windows.Forms.ColumnHeader();
            this.estadisticasListView = new System.Windows.Forms.ListView();
            this.metricHeader = new System.Windows.Forms.ColumnHeader();
            this.minHeader = new System.Windows.Forms.ColumnHeader();
            this.maxHeader = new System.Windows.Forms.ColumnHeader();
            this.avgHeader = new System.Windows.Forms.ColumnHeader();
            this.stdDevHeader = new System.Windows.Forms.ColumnHeader();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // procesosListView
            // 
            this.procesosListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.procesosListView.CheckBoxes = true;
            this.procesosListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processHeader,
            this.arrivalHeader,
            this.durationHeader,
            this.startTimeHeader,
            this.endTimeHeader,
            this.waitTimeHeader,
            this.responseTimeHeader,
            this.returnTimeHeader,
            this.stateHeader});
            this.procesosListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.procesosListView.FullRowSelect = true;
            this.procesosListView.GridLines = true;
            this.procesosListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.procesosListView.Location = new System.Drawing.Point(3, 3);
            this.procesosListView.MultiSelect = false;
            this.procesosListView.Name = "procesosListView";
            this.procesosListView.ShowGroups = false;
            this.procesosListView.Size = new System.Drawing.Size(794, 285);
            this.procesosListView.TabIndex = 0;
            this.procesosListView.UseCompatibleStateImageBehavior = false;
            this.procesosListView.View = System.Windows.Forms.View.Details;
            // 
            // processHeader
            // 
            this.processHeader.Text = "Proceso";
            this.processHeader.Width = 220;
            // 
            // arrivalHeader
            // 
            this.arrivalHeader.Text = "Llegada";
            this.arrivalHeader.Width = 90;
            // 
            // durationHeader
            // 
            this.durationHeader.Text = "Duración";
            this.durationHeader.Width = 90;
            // 
            // startTimeHeader
            // 
            this.startTimeHeader.Text = "Inicio";
            this.startTimeHeader.Width = 90;
            // 
            // endTimeHeader
            // 
            this.endTimeHeader.Text = "Fin";
            this.endTimeHeader.Width = 90;
            // 
            // waitTimeHeader
            // 
            this.waitTimeHeader.Text = "Espera";
            this.waitTimeHeader.Width = 90;
            //
            // responseTimeHeader
            //
            this.responseTimeHeader.Text = "Respuesta";
            this.responseTimeHeader.Width = 100;
            //
            // returnTimeHeader
            //
            this.returnTimeHeader.Text = "Retorno";
            this.returnTimeHeader.Width = 90;
            //
            // stateHeader
            //
            this.stateHeader.Text = "Estado";
            this.stateHeader.Width = 120;
            //
            // estadisticasListView
            //
            this.estadisticasListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.estadisticasListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.metricHeader,
            this.minHeader,
            this.maxHeader,
            this.avgHeader,
            this.stdDevHeader});
            this.estadisticasListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.estadisticasListView.FullRowSelect = true;
            this.estadisticasListView.GridLines = true;
            this.estadisticasListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.estadisticasListView.Location = new System.Drawing.Point(3, 294);
            this.estadisticasListView.MultiSelect = false;
            this.estadisticasListView.Name = "estadisticasListView";
            this.estadisticasListView.ShowGroups = false;
            this.estadisticasListView.Size = new System.Drawing.Size(794, 153);
            this.estadisticasListView.TabIndex = 1;
            this.estadisticasListView.UseCompatibleStateImageBehavior = false;
            this.estadisticasListView.View = System.Windows.Forms.View.Details;
            //
            // metricHeader
            //
            this.metricHeader.Text = "Métrica";
            this.metricHeader.Width = 180;
            //
            // minHeader
            //
            this.minHeader.Text = "Mínimo (min)";
            this.minHeader.Width = 130;
            //
            // maxHeader
            //
            this.maxHeader.Text = "Máximo (min)";
            this.maxHeader.Width = 130;
            //
            // avgHeader
            //
            this.avgHeader.Text = "Promedio (min)";
            this.avgHeader.Width = 150;
            //
            // stdDevHeader
            //
            this.stdDevHeader.Text = "Desv. estándar (min)";
            this.stdDevHeader.Width = 180;
            //
            // mainLayout
            //
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.procesosListView, 0, 0);
            this.mainLayout.Controls.Add(this.estadisticasListView, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.mainLayout.Size = new System.Drawing.Size(800, 450);
            this.mainLayout.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planificador de procesos PEPSI";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.mainLayout.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.ListView procesosListView;
        private System.Windows.Forms.ColumnHeader processHeader;
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
    }
}
