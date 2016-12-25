using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using wingateCSharp.EConnct;
using wingateCSharp.Interfaces;
using wingateCSharp.Validation;

namespace wingateCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\CodePros\\Documents\\Visual Studio 2015\\Projects\\comtrans_sop_import\\comtrans_sop_import\\data.csv";
            List<wingateSchema> data = null;
            var logger = LogManager.GetCurrentClassLogger();
            var fileReader = new FileReader(path,logger);

            //var values = "";
            //if (fileReader.TryRead(out values))
            //{
            //    if (String.IsNullOrEmpty(values))
            //    {
            //        return;
            //    }

            //}
            //fileReader.TrySplit(values,out data);



            // the faked split
            var splitRes = fileReader.TrySplit(out data);
            logger.Info("Start validation process");

            var validationFunctionsList = new List<IValidator>
            {
                new NotNullValidation(logger)
            };

            foreach(var row in data)
            {
                foreach(var validatorFunction in validationFunctionsList)
                {
                    validatorFunction.Validator(row.SupplierName);
                    validatorFunction.Validator(row.TransactionLineCodingGLAccountNumber);
                }
            }

            logger.Info("End validation process");
            var econnect = new EConnect(logger);
            var connectionString = "Server=DESKTOP-OH6TTHF\\SQLEXPRESS; Database=TWO;Trusted_Connection=True;User Id = DESKTOP-OH6TTHF\\CodePros";
            var vendorID = "sunTrust";
            var jentry = EConnectHelper.DocumentBuilder(connectionString);
            var invoiceDate = DateTime.Now;
            var invoiceNumber = "11124";

            var calculatedStatement = StatmentHelper.lineAmountSummation(data);
            var statement = 40m;

            if(calculatedStatement == statement)
            {
                econnect.TaPMTransactionInsert(jentry, data, connectionString, invoiceDate, vendorID, invoiceNumber);
            }
        }

    }
}
