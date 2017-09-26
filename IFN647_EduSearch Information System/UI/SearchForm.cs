using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFN647_EduSearch_Information_System.UI
{
    public partial class SearchForm : Form
    {
        public SearchForm(string path)
        {
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            string path = @"C:\temp\cran_information_needs.txt";

            System.IO.TextReader reader = new System.IO.StreamReader(path);
            string text = reader.ReadToEnd();
            Console.WriteLine(text);
            reader.Close();

            //separating query
            String[] substrings = text.Split(new char[] { '.', 'I', 'D' });
            foreach (var substring in substrings)
                Console.WriteLine(substring);
        }
    }
}
