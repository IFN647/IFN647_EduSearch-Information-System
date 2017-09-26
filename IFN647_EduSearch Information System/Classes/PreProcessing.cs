using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PorterStemmerAlgorithm;
using System.Text.RegularExpressions;

namespace IFN647_EduSearch_Information_System.Classes
{
    class PreProcessing
    {
        private PorterStemmer myStemmer;

        public PreProcessing()
        {
            myStemmer = new PorterStemmerAlgorithm.PorterStemmer();
        }


        //Source Documents Pre-Processing
        public List<string> sourceDocument_PreProcessing(string directoryPath)
        {
            List<string> sourcefiles = new List<string>();
            try
            {
                sourcefiles = Directory.GetFiles(directoryPath).ToList<string>();
                if (sourcefiles.Count > 0)
                {
                    foreach (string filePath in sourcefiles)
                    {
                        string line = "";
                        System.IO.StreamReader reader = new System.IO.StreamReader(filePath);
                        while ((line = reader.ReadToEnd()) != null)
                        {
                            line = Regex.Replace(line, ".I(.|\n)*?.T(.|\n)*?.A", string.Empty);
                            line = Regex.Replace(line, ".B", string.Empty);
                            line = Regex.Replace(line, ".W", string.Empty);
                            string[] tokens = TokeniseString(line);
                            string[] stems = StemTokens(tokens);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public string[] TokeniseString(string text)
        {
            char[] splitters = new char[] { ' ', '\t', '\'', '"', '-', '(', ')', ',', '’','\n', ':', ';', '?', '.', '!','W'};
            return text.ToLower().Split(splitters, StringSplitOptions.RemoveEmptyEntries);
        }

        public string[] StemTokens(string[] tokens)
        {
            int numTokens = tokens.Count();
            string[] stems = new string[numTokens];
            for (int i = 0; i < numTokens; i++)
            {
                stems[i] = myStemmer.stemTerm(tokens[i]);
            }
            return stems;
        }



        public List<string> informationNeeds_PreProcessing(string filePath)
        {
            return null;
        }
    }
}
