using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityCardSystem
{
    class Program
    {
        /// <summary>
        /// this class starts the process
        /// by calling the door scanner
        /// it also returns whether the scan
        /// results in the door opening or not
        /// </summary>
      
        static void Main(string[] args)
        {
            Program p = new Program();
            p.TestSecurityCardSystem();
            Console.ReadKey();
        }

        private void TestSecurityCardSystem()
        {
            //just substitute values here to test
            //different condition
            string card="200";
            string scanNumber="201";
            string status="closed";

            //call the scanner class and pass it the 
            //card, the scanner number and the door status
            Scanner scanner = new Scanner(card, scanNumber, status);
            //retrieve the new door status
            Console.WriteLine(scanner.DoorStatus);
        }
    }
}
