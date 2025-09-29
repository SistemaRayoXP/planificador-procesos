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
        }
    }
}
