using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityCardSystem
{
    class Scan
    {
        /// <summary>
        /// this class is just a collection of properties
        /// to hold the values for the scan
        /// </summary>
        public string CardNumber { get; set; }
        public DateTime ScanDateTime { get; set; }
        public string ScannerNumber { get; set; }
        public string DoorStatus { get; set; }
    }
}
