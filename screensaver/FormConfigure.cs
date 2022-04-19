using System;
using System.Windows.Forms;

namespace screensaver
{
    public partial class FormConfigure : Form
    {
        public FormConfigure()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.QuantLines = Convert.ToInt32(comboBox1.SelectedItem);
            Properties.Settings.Default.QuantDots = Convert.ToInt32(comboBox2.SelectedItem);
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
