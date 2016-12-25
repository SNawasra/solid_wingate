using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wingateCSharp.Interfaces;

namespace wingateCSharp
{
    class FileReader : IFileReader
    {
        private string Path {get; set;}

        public FileReader(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new Exception("Path couldn't be null");
            }

            this.Path = path;
        } 
        public bool TrySplit(string values, out List<wingateSchema> data)
        {
            data = null;
            return true;
        }

        public bool TrySplit (out List<wingateSchema> data)
        {
            //data = data.Replace('\n', ',');
            //string[] rows = data.Split('\n');
            //foreach (string row in rows)
            //{

            //}

            List<wingateSchema> temp = new List<wingateSchema>();
            //String[] values = data.Split(',');
            for (int i = 0; i < 5; i++)
            {
                wingateSchema x = new wingateSchema()
                {
                    RowId = i,
                    SupplierName = "Sameh" + i,
                    CardholderFirstName = "sameh" + i,
                    CardholderLastName = "Ahmed" + i,
                    TransactionLineAmount = 4m + i,
                    TransactionLineCodingGLAccountNumber = "111111",
                    Amount = 1.0M + i,
                    TransactionNotes = "Hi People"
                };
                temp.Add(x);
            }

            data = temp;
            return true;

        }
        public bool TryRead(out string values)
        {
            if (this.Exist())
            {
                values = File.ReadAllText(Path);
                return true;
            }

            values = null;
            return false;
        }

        public Boolean Exist()
        {
            if (!File.Exists(this.Path)) return true;
            else return false;
        }
    }
}
