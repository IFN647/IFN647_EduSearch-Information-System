using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFN647_EduSearch_Information_System
{
    public partial class MainForm : Form
    {
        private string SourceDirectoryPath = string.Empty;
        private string InfoNeedFilepath = string.Empty;
        Classes.PreProcessing ppObj;

        public MainForm()
        {
            InitializeComponent();
            ppObj = new Classes.PreProcessing();
            //InfoNeedFilepath = @"C:\Users\Yasiru\Desktop\IFN647\Project\collection\cran_information_needs.txt";
            populate_InformationNeedsCheckBox();
        }


        private void button1_Click_1(object sender, EventArgs e) // Source directory browse button
        {
            textBox1.Text = getDirectoryPath();
        }

        private void button2_Click(object sender, EventArgs e) // Index directory browse button
        {
            textBox2.Text = getDirectoryPath();
        }

        private void button3_Click(object sender, EventArgs e) // Build index button
        {
            ppObj.sourceDocument_PreProcessing(textBox1.Text);
            System.Windows.Forms.MessageBox.Show(this,"Build successful. Time = ", "Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public string getDirectoryPath() // Open folder browser dialog
        {
            string path = string.Empty;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;
                }
            }
            return path;
        }

        private void populate_InformationNeedsCheckBox()
        {
            var informationNeeds = ppObj.informationNeeds_PreProcessing(InfoNeedFilepath);
            foreach (var item in informationNeeds)
            {
                ListBox lItem = new ListBox();
                lItem.Name = item.TopicID;
                lItem.Text = item.Description;
                checkedListBox1.Items.Add(item.Description, false);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            populate_InformationNeedsCheckBox();
        }
    }
}
