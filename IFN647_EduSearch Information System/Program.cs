using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFN647_EduSearch_Information_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string path = @"C:\temp\cran_information_needs.txt";

            // SOLUTION 1
            System.IO.TextReader reader = new System.IO.StreamReader(path);
            string text = reader.ReadToEnd();
            Console.WriteLine(text);
            reader.Close();

            //separating query
            String[] substrings = text.Split(new char[] { '.', 'I', 'D' });
            foreach (var substring in substrings)
                Console.WriteLine(substring);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
// it must work this time hhhh