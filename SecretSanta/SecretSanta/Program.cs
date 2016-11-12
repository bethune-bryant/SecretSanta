using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecretSanta
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string filename = args.Count() > 0 ? args[0] : "";
            string email = args.Count() > 1 ? args[1] : "";
            string password = args.Count() > 2 ? args[2] : "";
            int seed = args.Count() > 3 ? int.Parse(args[3]) : (int)DateTime.Now.TimeOfDay.TotalMilliseconds;

            Application.Run(new Form1(filename, seed, email, password));
        }
    }
}
