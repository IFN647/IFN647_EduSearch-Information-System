using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFN647_EduSearch_Information_System.UI
{
    public partial class IndexForm : Form
    {
        public IndexForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string SourceDirectoryPath = "";
            string InfoNeedFilepath = "";
            Form SchFrom = new UI.SearchForm(SourceDirectoryPath, InfoNeedFilepath);
            SchFrom.Show();
            this.Hide();
        }
    }
}
