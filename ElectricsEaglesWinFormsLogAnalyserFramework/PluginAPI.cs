using Razorvine.Pickle;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ElectricsEaglesWinFormsLogAnalyserFramework
{
    class PluginAPI
    {
		List<CheckBox> main = new List<CheckBox>();
		public String[] detect_plugins()
        {
           return  Directory.GetFiles("./plugins");
        }


		public void generate_form()
		{

			var data = detect_plugins();
		
			using (Form form = new Form())
			{
				form.Padding = new Padding(10);
				for (int a = 0; a < data.Length; a++)
				{
					CheckBox sample = new CheckBox();
					sample.Text = data[a];
					sample.AutoSize = true;
					sample.Location = new Point(10, 100 + (25 * a)); //vertical
					main.Add(sample);

				}
					foreach(CheckBox checkBox in main.ToArray())
                    {
						form.Controls.Add(checkBox);
					}
				Button main_button = new Button();
				main_button.Location= new Point((form.Width-100)/2, 100 + (25 * data.Length+2)); //vertical
				main_button.AutoSize = true;
				main_button.Text = "Run Selected  Plugins";
				main_button.Click += button_hadler;
				form.Controls.Add(main_button);
				form.ShowDialog();
			}
		}

		public void button_hadler(object sender, EventArgs e)
        {
			foreach (CheckBox checkBox in main.ToArray())
			{
                if (checkBox.Checked){
					var plugin_path = Path.GetFullPath(checkBox.Text);
					


					System.Diagnostics.Process process = new System.Diagnostics.Process();
					System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
					startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
					startInfo.WorkingDirectory = Path.GetFullPath("./plugins");
					startInfo.FileName = "cmd.exe";
					startInfo.Arguments = "/C py " + plugin_path;
					process.StartInfo = startInfo;
					process.Start();

				




				}
			}
		}
		public void make_pickle(List<List<Int32>> main)
        {
			
			// You can add many other types if you like. See the readme about the type mappings.

			const string pickleFilename = "./plugins/data/program_data.dat";

			Console.WriteLine("Writing pickle to '{0}'", pickleFilename);

			var pickler = new Pickler(true);
			using (FileStream fos = new FileStream(pickleFilename, FileMode.Create))
			{
				pickler.dump(main, fos);
			}
		}
    }

	
}
