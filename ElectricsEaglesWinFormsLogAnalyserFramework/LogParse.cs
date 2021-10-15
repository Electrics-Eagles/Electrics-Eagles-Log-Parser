using System;
using System.Collections.ObjectModel;
using System.IO;

namespace ElectricsEaglesWinFormsLogAnalyserFramework
{
    class LogParse
    {

        public ObservableCollection<PacketOfData> get_raw_logs(String path)
        {
            ObservableCollection<PacketOfData> logs_value = new ObservableCollection<PacketOfData>();



            var array = File.ReadAllLines(path);




            for (int i = 1; i < array.Length; i++)
            {
                {
                    var data = array[i].Split(',');
                    if (data.Length > 20)
                    {

                        PacketOfData packetOfData = new PacketOfData();
                        try
                        {
                            packetOfData.all.Add(data[1]);
                            packetOfData.all.Add(data[2]);
                            packetOfData.all.Add(data[3]);
                            packetOfData.all.Add(data[4]);
                            packetOfData.all.Add(data[5]);
                            packetOfData.all.Add(data[6]);
                            packetOfData.all.Add(data[7]);
                            packetOfData.all.Add(data[8]);
                            packetOfData.all.Add(data[9]);
                            packetOfData.all.Add(data[10]);
                            packetOfData.all.Add(data[11]);
                            packetOfData.all.Add(data[12]);
                            packetOfData.all.Add(data[13]);
                            packetOfData.all.Add(data[14]);
                            packetOfData.all.Add(data[15]);
                            packetOfData.all.Add(data[16]);
                            packetOfData.all.Add(data[17]);
                            packetOfData.all.Add(data[18]);
                            packetOfData.all.Add(data[19]);
                            packetOfData.all.Add(data[20]);
                            packetOfData.all.Add(data[21]);
                            packetOfData.all.Add(data[22]);
                            packetOfData.all.Add(data[23]);
                            packetOfData.all.Add(data[24]);
                            packetOfData.all.Add(data[25]);
                            packetOfData.all.Add(data[26]);
                            packetOfData.all.Add(data[27]);
                            logs_value.Add(packetOfData);
                        }
                        catch (IndexOutOfRangeException)
                        {

                        }

                    }

                    else
                    {

                    }

                }



            }


            return logs_value;
        }
    }
}

