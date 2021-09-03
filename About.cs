using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricsEaglesWinFormsLogAnalyserFramework
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {

            // Create a resource manager to retrieve resources.
         
            label1.Text = "Runing on: "+new ComputerInfo().OSFullName;
            label3.Text = "Theme in usage :  Classic";
            label1.Text = "Runing on: " + new ComputerInfo().OSFullName;

            label2.Text = "Version:" + Application.ProductVersion;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Electrics-Eagles/PiElectricsEagles");
        }
    }
}
