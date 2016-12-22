using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wingateCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\CodePros\\Documents\\Visual Studio 2015\\Projects\\comtrans_sop_import\\comtrans_sop_import\\data.csv";
            string [] values = File.ReadAllText(path).Split(',');
            Console.WriteLine(values);
        }
    }
}
