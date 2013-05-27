using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityCardSystem
{
    class Scanner
    {
        /// <summary>
        /// The Scanner class represents the scanner
        /// on the door. The fields represent all 
        /// the information contained in a particular
        /// scan. The doorStatus also exposes
        /// a read only property. CreateScan() creates
        /// and populates the Scan object
        /// GetValidation sends the scan to the validator.
        /// If the validator returns true for the permission
        /// the status of the door is changed to open
        /// </summary>
        private string cardNumber;
        private DateTime scanDateTime;
        private string scannerNumber;
        private string doorStatus;
        private Scan scan;

        public Scanner(string card, string scanNumber, string status)
        {
            //the constructor populates most of the
            //values needed for the scan
            cardNumber = card;
            scannerNumber = scanNumber;
            scanDateTime = DateTime.Now;
            doorStatus = status;
            scan = null;
            //calls CreateScan and GetValidation methods
            CreateScan();
            GetValidation();

        }

        //read only property
        public string DoorStatus
        {
            get { return doorStatus; }
        }

        //populates the scan
        private void CreateScan()
        {
            scan = new Scan();
            scan.CardNumber = cardNumber;
            scan.ScanDateTime = scanDateTime;
            scan.ScannerNumber = scannerNumber;
            scan.DoorStatus = DoorStatus;
            
        }

        //sends the scan to the ScanValidator
        //and recieves the result back
        private void GetValidation()
        {
            ScanValidator validator= new ScanValidator(scan);
            bool valid = validator.Permission;
            if (valid)
            {
                doorStatus = "Open";
            }
        }

    }
}
