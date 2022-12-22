using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bmorris_launcher
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("press esc to exit");
            proxy11.Start();
            //dont close the program
            while (true)
            {
                //if the user presses the escape key
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    //close the program
                    proxy11.Stop();
                    Environment.Exit(0);
                }
            }


        }
    }
}
