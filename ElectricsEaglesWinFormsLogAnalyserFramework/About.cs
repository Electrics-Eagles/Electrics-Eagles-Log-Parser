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
            PluginAPI pluginAPI = new PluginAPI();
            StringBuilder plugins = new StringBuilder();
            plugins.Append("Plugins loaded:");
            foreach (String plugin in pluginAPI.detect_plugins())
            {
                plugins.Append(plugin);
                plugins.Append("\n");
            }
            richTextBox1.Text = plugins.ToString();
               
            // Create a resource manager to retrieve resources.

            label1.Text = "Runing on: "+new ComputerInfo().OSFullName;
            label3.Text = "Theme in usage :  Windows Default";
            label1.Text = "Runing on: " + new ComputerInfo().OSFullName;

            label2.Text = "Version:" + " v1.0.2 x64 Bit . ";
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
