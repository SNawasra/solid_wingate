using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using wingateCSharp.Interfaces;
using wingateCSharp.Validation;

namespace wingateCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = "C:\\Users\\CodePros\\Documents\\Visual Studio 2015\\Projects\\comtrans_sop_import\\comtrans_sop_import\\data.csv";
            //string [] values = File.ReadAllText(path).Split(',');

            List<wingateSchema> data = null;
            var logger = LogManager.GetCurrentClassLogger();

            var fileReader = new FileReader(path,logger);

            //var values = "";
            //if (fileReader.Exist())
            //{
            //    if(fileReader.TryRead(out values))
            //    {
            //        if (String.IsNullOrEmpty(values))
            //        {
            //            exist(0);
            //        }
            //    }
            //}

            var splitRes = fileReader.TrySplit(out data);
            var validationFunctionsList = new List<IValidator>
            {
                new NotNullValidation()
            };

            foreach(var row in data)
            {
                foreach(var validatorFunction in validationFunctionsList)
                {
                    validatorFunction.Validator(row.SupplierName);
                    validatorFunction.Validator(row.TransactionLineCodingGLAccountNumber);
                }
            }       
        }
    }
}
