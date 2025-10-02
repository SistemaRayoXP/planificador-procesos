namespace Planificador
{
    partial class MainForm
    {
      
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

       
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "Descarga 1", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00" }, -1);
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "Descarga 2", "00:03", "00:03", "00:03", "00:03", "00:03", "00:03" }, -1);
            ListViewItem listViewItem3 = new ListViewItem(new string[] { "Descarga 3", "00:05", "00:05", "00:05", "00:05", "00:05", "00:05" }, -1);
            listView1 = new ListView();
            processHeader = new ColumnHeader();
            arrivalHeader = new ColumnHeader();
            durationHeader = new ColumnHeader();
            startTimeHeader = new ColumnHeader();
            endTimeHeader = new ColumnHeader();
            waitTimeHeader = new ColumnHeader();
            returnTimeHeader = new ColumnHeader();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.BorderStyle = BorderStyle.FixedSingle;
            listView1.CheckBoxes = true;
            listView1.Columns.AddRange(new ColumnHeader[] { processHeader, arrivalHeader, durationHeader, startTimeHeader, endTimeHeader, waitTimeHeader, returnTimeHeader });
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewItem1.Checked = true;
            listViewItem1.StateImageIndex = 1;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3 });
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.ShowGroups = false;
            listView1.Size = new Size(800, 450);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.ItemCheck += listView1_ItemCheck;
            // 
            // processHeader
            // 
            processHeader.Text = "Proceso";
            processHeader.Width = 250;
            // 
            // arrivalHeader
            // 
            arrivalHeader.Text = "Tiempo de llegada";
            arrivalHeader.Width = 140;
            // 
            // durationHeader
            // 
            durationHeader.Text = "Duración";
            durationHeader.Width = 75;
            // 
            // startTimeHeader
            // 
            startTimeHeader.Text = "Inicio";
            // 
            // endTimeHeader
            // 
            endTimeHeader.Text = "Fin";
            // 
            // waitTimeHeader
            // 
            waitTimeHeader.Text = "Espera";
            // 
            // returnTimeHeader
            // 
            returnTimeHeader.Text = "Tiempo de retorno";
            returnTimeHeader.Width = 140;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Planificador de procesos PEPSI";
            Shown += MainForm_Shown;
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader processHeader;
        private ColumnHeader arrivalHeader;
        private ColumnHeader durationHeader;
        private ColumnHeader startTimeHeader;
        private ColumnHeader endTimeHeader;
        private ColumnHeader waitTimeHeader;
        private ColumnHeader returnTimeHeader;
    }
}
