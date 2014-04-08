using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DSCHelper.Models
{
    public class FileHostMatch
    {
        public string guid { get; set; }
        public string servername { get; set; }
    }

    public class HostGuidReader
    {
        public string ReadHostGuid(string Hostname)
        {
            string filepath = DSCHelper.Properties.Settings.Default.MofFolder;
            DirectoryInfo di = new System.IO.DirectoryInfo(filepath);
            
            var files = di.GetFiles("*.mof");

            //string[,] array = new string[files.Count(),1];
            //FileHostMatch[] FileHostMatchArray;
            List<FileHostMatch> list = new List<FileHostMatch>();
            int counter = 0;
            foreach (FileInfo file in files)
            {
                // get the content of the file
            
                string[] lines = System.IO.File.ReadAllLines(file.FullName);
                string line2 = lines[1];
                line2 = line2.Replace("@TargetNode=", "");
                line2 = line2.Replace("'", "");

                string BaseFileName = Path.GetFileNameWithoutExtension(file.FullName);
                
                FileHostMatch match = new FileHostMatch();
                match.guid = BaseFileName;
                match.servername = line2;
                
                list.Add(match);

                counter ++;
            }

            //string guid = 
            try
            {
                FileHostMatch SingleMatch = list.Single(c => c.servername.ToLower() == Hostname.ToLower());
                return SingleMatch.guid;
            }
            catch (Exception)
            {
                return null;
                
            }

           
        }

    }
}