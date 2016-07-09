using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    public class DirectorySearch
    {
        public void ProcessDirectory(string targetDirectory, string substring)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(targetDirectory);
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Name.IndexOf(substring) >= 0)
                    {
                        Console.WriteLine(file.Name + ", " + file.Length);
                    }
                }
                string[] subdirectories = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectories)
                {
                    ProcessDirectory(subdirectory, substring);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }
}
