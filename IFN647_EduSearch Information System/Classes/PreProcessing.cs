using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace IFN647_EduSearch_Information_System.Classes
{
    class PreProcessing
    {

        //Source Documents Pre-Processing
        public List<SourceDocument> sourceDocument_PreProcessing(string directoryPath)
        {
            List<SourceDocument> sourceDocuments = new List<SourceDocument>();
            try
            {
                string[] sourcefiles = Directory.GetFiles(directoryPath, "*.txt");
                if (sourcefiles.Length > 0)
                {
                    foreach (string filePath in sourcefiles)
                    {
                        SourceDocument sourceDocument = new SourceDocument();
                        System.IO.StreamReader reader = new System.IO.StreamReader(filePath);
                        string txtData = reader.ReadToEnd();
                        txtData = Regex.Replace(txtData, @"\t|\n|\r", "");
                        int End_Pos_I = txtData.IndexOf(".I") + ".I".Length;
                        int Start_Pos_T = txtData.IndexOf(".T");
                        sourceDocument.DocID = txtData.Substring(End_Pos_I, Start_Pos_T - End_Pos_I).Trim();

                        int End_Pos_T = txtData.IndexOf(".T") + ".T".Length;
                        int Start_Pos_A = txtData.IndexOf(".A");
                        string temp = txtData.Substring(End_Pos_T, Start_Pos_A - End_Pos_T);
                        sourceDocument.Title = temp.Replace(".", "").Trim();

                        int End_Pos_A = txtData.IndexOf(".A") + ".A".Length;
                        int Start_Pos_B = txtData.IndexOf(".B");
                        sourceDocument.Author = txtData.Substring(End_Pos_A, Start_Pos_B - End_Pos_A).Trim();

                        int End_Pos_B = txtData.IndexOf(".B") + ".B".Length;
                        int Start_Pos_W = txtData.IndexOf(".W");
                        sourceDocument.BibInfo = txtData.Substring(End_Pos_B, Start_Pos_W - End_Pos_B).Trim().TrimEnd('.');

                        int End_Pos_W = txtData.IndexOf(".W") + ".W".Length;
                        sourceDocument.Text = txtData.Substring(End_Pos_W + temp.Length).Trim();
                        sourceDocuments.Add(sourceDocument);
                        reader.Close();
                    }
                }else
                {
                    //No files found
                }
            }
            catch (Exception)
            {

                throw;
            }
            return sourceDocuments;
        }

        //Infromation Needs Pre-Processing
        public List<InformationNeed> informationNeeds_PreProcessing(string filePath)
        {
            List<InformationNeed> InformationNeeds = new List<InformationNeed>();
            try
            {
                if (Path.GetExtension(filePath)==".txt")
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(filePath);
                    string txtData = reader.ReadToEnd();
                    txtData = Regex.Replace(txtData, @"\t|\n|\r", "");

                    String[] data = Regex.Split(txtData,".I");
                    foreach (string item in data)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            InformationNeed InformationNeed = new InformationNeed();
                            String[] substrings = Regex.Split(item, ".D");
                            InformationNeed.TopicID = substrings[0].Trim();
                            InformationNeed.Description = Regex.Replace(substrings[1],"\"","").TrimEnd('.').Trim();
                            InformationNeeds.Add(InformationNeed);            
                        }
                    }
                    reader.Close();
                }else
                {
                    // Not a Valid text file
                }
            }
            catch (Exception)
            {
                throw;
            }
            return InformationNeeds;
        }
    }
}
