using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Diagnostics;

namespace BHX560ProgramCheck
{
    class Work
    {
        Data dbTasks = new Data();

        public void LoadData()
        {
            List<string> jobsMissing = new List<string>();
            DataTable partData = dbTasks.GetPartData();
            foreach(DataRow row in partData.Rows)
            {
                var a = row[3];
                bool exists = File.Exists("\\\\10.105.60.1\\d\\control\\m60-c1\\data\\cnc\\mp4\\Destination\\" + a + ".mpr");
                if(!exists && !jobsMissing.Contains(row[0].ToString()))
                {
                    jobsMissing.Add(row[0].ToString());
                    //if (row[0].ToString() == "B112727")
                    //{
                    //    break;
                    //}

                }
            }
            foreach(string job in jobsMissing)
            {
                File.Copy(@"O:\BSAW\Data\Import\MachineCSV\BHX\" + job + "BHXDP.csv", @"\\10.105.60.1\e\CustomerData\CSV\" + job + "BHXDP.csv");
            }
            Debug.Write("Done");
        }
    }
}
