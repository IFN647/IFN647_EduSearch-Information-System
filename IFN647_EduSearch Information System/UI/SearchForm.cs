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
        public SearchForm(string SourceDirectoryPath, string InfoNeedFilepath)
        {
            InitializeComponent();

            Classes.PreProcessing p = new Classes.PreProcessing();
            //SourceDirectoryPath = @"C:\Users\Yasiru\Desktop\IFN647\Project\collection\crandocs";
            //InfoNeedFilepath = @"C:\Users\Yasiru\Desktop\IFN647\Project\collection\cran_information_needs.txt";
            p.informationNeeds_PreProcessing(InfoNeedFilepath);
            p.sourceDocument_PreProcessing(SourceDirectoryPath);
        }

    }
}
