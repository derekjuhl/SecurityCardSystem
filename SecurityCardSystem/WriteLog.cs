using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SecurityCardSystem
{
    class WriteLog
    {
        /// <summary>
        /// This class writes the scan contents
        /// and the results to a text file
        /// the constructor takes in the scan and the
        /// permission results from the validator
        /// </summary>

        private Scan scan;
        private bool permission;
        
        //the constructor takes two arguments:
        //a scan object and a boolean which 
        //conveys whether permission was granted
        //or denied
        public WriteLog(Scan scan, bool permission)
        {
            this.scan = scan;
            this.permission = permission;
            //call the WriteLogEntry() method
            WriteLogEntry();
        }

        private void WriteLogEntry()
        {
            //here we initiate the stream writer with a filename
            //the true means append rather than overwrite

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"scanlog.txt", true))
            {
                //the stringbuilder builds a comma delimitted string
                //from the scan objects properties
                StringBuilder builder = new StringBuilder();
                builder.Append(scan.CardNumber);
                builder.Append(", ");
                builder.Append(scan.ScannerNumber);
                builder.Append(", ");
                builder.Append(scan.ScanDateTime.ToString());
                builder.Append(", ");
                builder.Append(permission.ToString());
               
                //this line writes it all to file
                file.WriteLine(builder.ToString());
                
            }
        }
    }
}
