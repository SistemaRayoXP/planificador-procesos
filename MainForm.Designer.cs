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
            this.returnTimeHeader = new System.Windows.Forms.ColumnHeader();
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
            this.returnTimeHeader});
            this.procesosListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.procesosListView.FullRowSelect = true;
            this.procesosListView.GridLines = true;
            this.procesosListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.procesosListView.Location = new System.Drawing.Point(0, 0);
            this.procesosListView.MultiSelect = false;
            this.procesosListView.Name = "procesosListView";
            this.procesosListView.ShowGroups = false;
            this.procesosListView.Size = new System.Drawing.Size(800, 450);
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
            // returnTimeHeader
            // 
            this.returnTimeHeader.Text = "Retorno";
            this.returnTimeHeader.Width = 90;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.procesosListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planificador de procesos PEPSI";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView procesosListView;
        private System.Windows.Forms.ColumnHeader processHeader;
        private System.Windows.Forms.ColumnHeader arrivalHeader;
        private System.Windows.Forms.ColumnHeader durationHeader;
        private System.Windows.Forms.ColumnHeader startTimeHeader;
        private System.Windows.Forms.ColumnHeader endTimeHeader;
        private System.Windows.Forms.ColumnHeader waitTimeHeader;
        private System.Windows.Forms.ColumnHeader returnTimeHeader;
    }
}
