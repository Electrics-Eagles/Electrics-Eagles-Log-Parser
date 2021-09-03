using System;
using System.Collections.Generic;

namespace ElectricsEaglesWinFormsLogAnalyserFramework
{
    public class PacketOfData
    {
        private List<String> all_together = new List<String>();

        public List<String> all
        {
            set { all_together = value; }
            get { return all_together; }
        }
    }
}
