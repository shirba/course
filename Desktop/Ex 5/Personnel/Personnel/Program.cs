using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            const string FILE_PATH = "../../names.txt";
            List<string> names = new List<string>();
            try
            {
                using (StreamReader file = new StreamReader(FILE_PATH))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        names.Add(line);
                    }
                    file.Close();
                }
                foreach (string name in names)
                {
                    Console.WriteLine(name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading file: {0}", e.Message);
            }
        }
    }
}
