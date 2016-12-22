using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wingateCSharp
{
    class FileRead
    {
        public bool TrySplit (string values, out wingateSchema [] data)
        {
            //data = data.Replace('\n', ',');
            //string[] rows = data.Split('\n');
            //foreach (string row in rows)
            //{

            //}

            //String[] values = data.Split(',');
            for (int i = 0; i < 5; i++)
            {
                wingateSchema x = new wingateSchema()
                {
                    RowId = i,
                    SupplierName = "Sameh" + i,
                    CardholderFirstName = "sameh" + i,
                    CardholderLastName = "Ahmed" + i,
                    TransactionLineAmount = "4" + i,
                    TransactionLineCodingGLAccountNumber = "111111",
                    Amount = 1.0M + i,
                    TransactionNotes = "Hi People"
                };
            }
            data = null;
            return true;

        }
        public bool Read(string path, out string values)
        {
            if (this.Exist(path))
            {
                values = File.ReadAllText(path);
                return true;
            }

            values = null;
            return false;
        }

        public Boolean Exist(string path)
        {
            if (!File.Exists(path)) return true;
            else return false;
        }
    }
}
