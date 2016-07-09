using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2 || String.IsNullOrEmpty(args[1]) || String.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Please start again and insert 2 valid parameters.");                
            }
            else
            {
                DirectorySearch dirSearcher = new DirectorySearch();
                dirSearcher.ProcessDirectory(args[0], args[1]);
            }
        }
       
    }
}
