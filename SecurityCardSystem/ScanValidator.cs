using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SecurityCardSystem
{
    class ScanValidator
    {
        /// <summary>
        /// This class recieves the scan and validates it
        /// against an xmlfile. The xml file is a temporary
        /// substitute for a database
        /// Try catches are used for the file access
        /// because it is always possible the file will
        /// not be found
        /// </summary>
        private Scan scan;
        private bool permission;

        public ScanValidator(Scan s)
        {
            scan = s;
            try
            {
                //sets the permission based on validate scan
                permission = ValidateScan();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //calls the method to write the entry to a log
            LogEntry();
        }

        private bool ValidateScan()
        {
            //initial setting for permission
            permission = false;
            //create a new dataset to store the data
            //from the xml file
            DataSet scanTable = new DataSet();
            try
            {
                //read the xml file
                scanTable.ReadXml(@"carddata.xml");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            foreach (DataRow row in scanTable.Tables["carduser"].Rows)
            {
                //check the data in the scan against the data in the xml file
                if (row["card"].ToString().Equals(scan.CardNumber)
                    && scan.ScannerNumber.Equals(row["door"].ToString())
                    && scan.ScanDateTime >= DateTime.Parse(row["begindate"].ToString())
                    && scan.ScanDateTime <= DateTime.Parse(row["enddate"].ToString())
                    && scan.ScanDateTime >= DateTime.Parse(row["starttime"].ToString())
                    && scan.ScanDateTime <= DateTime.Parse(row["endtime"].ToString()))
                {
                    permission = true;
                }
            }

            return permission;
        }

        //public read only permission for Permission
        public bool Permission
        {
            get { return permission; }
        }

        private void LogEntry()
        {
            //call the WriteLog class and pass the scan and permission
            //to the class to be written to the log
            WriteLog log = new WriteLog(scan, Permission);
        }
    }
}
