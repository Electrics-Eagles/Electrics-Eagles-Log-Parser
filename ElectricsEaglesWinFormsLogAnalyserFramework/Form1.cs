using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ElectricsEaglesWinFormsLogAnalyserFramework
{
    public partial class Form1 : Form
    {
        public static string[] names = { "acc_x", "acc_y", "acc_z", "gyro_x", "gyro_y", "gyro_z", "angle_pitch_acc", "angle_roll_acc", "esc_1", "esc_2", "esc_3", "esc_4", "reciver_ch1", "reciver_ch2", "reciver_ch3", "reciver_ch4", "reciver_ch5", "reciver_ch6", "pid_output_pitch", "pid_output_roll", "pid_pitch_setpoint", "pid_roll_setpoint", "pid_yaw_setpoint", "pitch_level_correction", "roll_level_correction", "time_spent", "temp" };
        bool was_used_before;
        public static String com_port;
        public static int baudrate;
        string filepath;
        public static List<CheckBox> checkBoxes = new List<CheckBox>();
        public static Chart form_chart;

        public Form1()
        {
            
            OperatingSystem os = Environment.OSVersion;
            Console.WriteLine($"platform:       {os.Platform}\n" +
                  $"version:        {os.Version}\n" +
                  $"version string: {os.VersionString}");


          
            InitializeComponent();
            PluginAPI pluginAPI = new PluginAPI();
            Console.WriteLine(pluginAPI.detect_plugins());
            add_checkbox();
            this.Size = new System.Drawing.Size(Screen.AllScreens[0].WorkingArea.Width, Screen.AllScreens[0].WorkingArea.Height);
            form_chart = this.chart1;
            Chart.CheckForIllegalCrossThreadCalls = false;
            chart1.SuppressExceptions = true;
            label2.Text = new ComputerInfo().OSFullName;
            this.Text = "Electrics Eagles Logs Parser Windows x64";

        }


        public void add_checkbox()
        {
            for (int i = 0; i < names.Length; i++)
            {
                CheckBox box;
                box = new CheckBox();
                box.Text = names[i];
                box.AutoSize = true;
                box.Location = new Point(10, 100 + (25 * i)); //vertical
                checkBoxes.Add(box);                    //box.Location = new Point(i * 50, 10); //horizontal
                this.Controls.Add(box);
            }

        }



        public void zoom(int val)
        {

            var ok = checkBox1.Checked;
            if (ok == true)
            {
                chart1.ChartAreas[val].AxisX.MajorGrid.Enabled = true;
                chart1.ChartAreas[val].AxisX.MinorGrid.Enabled = true;
                chart1.ChartAreas[val].AxisY.MajorGrid.Enabled = true;
                chart1.ChartAreas[val].AxisY.MinorGrid.Enabled = true;
            }
            else if (checkBox1.Checked == false)
            {
                chart1.ChartAreas[val].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas[val].AxisX.MinorGrid.Enabled = false;
                chart1.ChartAreas[val].AxisY.MajorGrid.Enabled = false;
                chart1.ChartAreas[val].AxisY.MinorGrid.Enabled = false;
            }




            chart1.ChartAreas[val].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[val].AxisX.ScaleView.ZoomReset();

            chart1.ChartAreas[val].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[val].CursorX.AutoScroll = true;
            chart1.ChartAreas[val].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[val].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[val].CursorY.AutoScroll = true;
            chart1.ChartAreas[val].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[val].RecalculateAxesScale();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (was_used_before == false)
            {
                OpenFileDialog file_to_parse = new OpenFileDialog();
                file_to_parse.Title = "Select log file";
                file_to_parse.ShowDialog();
                if (file_to_parse.FileName != null)
                {
                    filepath = file_to_parse.FileName;
                    was_used_before = true;
                }
            }




            if (was_used_before)
            {
                button1.Text = "Display on Graph";
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.ResetAutoValues();
                chart1.Update();
                chart1.Refresh();

                ChartArea myArea = new ChartArea("Default");
                was_used_before = true;
                chart1.ChartAreas.Add(myArea);

                List<List<Int32>> main = new List<List<Int32>>();
                var info = new List<KeyValuePair<int, int>>();

                List<List<Int32>> to_pickle = new List<List<Int32>>();

                List<Int32> index = new List<Int32>();
                List<Int32> display = new List<Int32>();
                LogParse logParse = new LogParse();
                var data = logParse.get_raw_logs(filepath);

                for (int a = 0; a < checkBoxes.Count; a++)
                {

                    if (checkBoxes[a].Checked)
                    {
                        display.Add(a);
                    }

                }


                var count = display.Count;
                for (int d = 0; d < checkBoxes.Count; d++)
                {
                    List<Int32> list = new List<Int32>();

                    for (int l = 0; l < data.Count; l++)
                    {
                        int val;
                        Int32.TryParse(data[l].all[d].Split('.')[0], out val);
                        list.Add(val);

                    }
                    main.Add(list);

                }
                
                     foreach(int z in display.ToArray())
                    {
                    to_pickle.Add(main[z]);
                    }

            /////////        }

               

                for (int f = 0; f < data.Count; f++)
                {
                    index.Add(f);
                }

               
                 if(checkBox2.Checked ==true)
                {

                    PluginAPI pluginAPI = new PluginAPI();
                    pluginAPI.make_pickle(to_pickle);
                    pluginAPI.generate_form();



                }
                zoom(chart1.ChartAreas.Count - 1);
                for (int d = 0; d < display.Count; d++)
                {
                    var mySeries = new Series(names[display[d]]);
                    mySeries.ChartType = SeriesChartType.Line;
                    mySeries.LegendText = names[display[d]];
                    mySeries.BorderWidth = trackBar1.Value;
                    mySeries.Points.DataBindXY(index.ToArray(), main[display[d]].ToArray());
                    chart1.Series.Add(mySeries);

                }


            }
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Size of Line in  graph: " + trackBar1.Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(this);
            settings.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void serialThread_Call()
        {
            SerialReadData serialReadData = new SerialReadData();
            serialReadData.open();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Settings settings = new Settings(this);
            settings.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < checkBoxes.Count; i++)
            {
                var mySeries = new Series(names[i]);
                mySeries.ChartType = SeriesChartType.Line;
                mySeries.LegendText = names[i];
                mySeries.BorderWidth = trackBar1.Value;
               
                chart1.Series.Add(mySeries);
            }
            Console.WriteLine("logg");
            Thread serialRead = new Thread(serialThread_Call);
            serialRead.Start();
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            new About().Show();
        }
     
        private void button6_Click(object sender, EventArgs e)
        {

            printDocument1.DocumentName = names[0];
            printPreviewDialog1.Document = chart1.Printing.PrintDocument;
            printPreviewDialog1.ShowDialog();
            printDialog1.Document = chart1.Printing.PrintDocument;
            printDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            was_used_before = false;
            button1_Click(sender,e);

        }
    }
}
