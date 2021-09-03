using System;
using System.Windows.Forms;

namespace ElectricsEaglesWinFormsLogAnalyserFramework
{
    public partial class Settings : Form
    {
        private Form1 main_form_private;

        string[] baudrates = { "110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "38400", "57600", "115200", "128000", "256000" };
        public Settings(Form1 main_form_private)
        {
            this.main_form_private = main_form_private;

            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                comboBox1.Items.Add("COM" + i.ToString());
            }

            foreach (String baud in baudrates)
            {
                comboBox2.Items.Add(baud);
            }

        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.com_port = comboBox1.Text;
            int val;
            if (Int32.TryParse(comboBox2.Text, out val))
            {
                Form1.baudrate = val;
            }

            else
            {
                Form1.baudrate = 9600;
                MessageBox.Show("No any baudrate set . Set 9600 as default");
            }
        }
    }
}
