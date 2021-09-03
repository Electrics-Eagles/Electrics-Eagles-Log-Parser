using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ElectricsEaglesWinFormsLogAnalyserFramework
{
    class SerialReadData
    {
        public Chart chart1;
        public static List<CheckBox> checkboxses = new List<CheckBox>();
        private static String[] names;

        public void open()
        {   this.chart1 = Form1.form_chart;
            checkboxses= Form1.checkBoxes ;
            lock (chart1.Series)
            {
                int i = 0;
                List<Int32> awesome = new List<Int32>();
                int[] array = new int[1024];
                checkboxses = Form1.checkBoxes;
                names = Form1.names;
                SerialPort serialPort = new SerialPort(Form1.com_port, Form1.baudrate);
                serialPort.Open();
                if (serialPort.IsOpen)
                {
                    while (true)
                    {

                       
                            i = i + 1;
                        var data = serialPort.ReadLine();
                        var input_data = data.Replace("::", ";").Split(';')[1].Split('.')[0];
                        Console.WriteLine(input_data);
                        var data_val = Int32.Parse(input_data);
               
                        array[i] = data_val;

                        Console.WriteLine(array.Length);
                        chart1.Series[0].Points.DataBindY(array);
                        chart1.Series[0].ChartType = SeriesChartType.Line;


                     

                    }
                    }
                }

            }
        }
    }


