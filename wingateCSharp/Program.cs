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
            var logger = LogManager.GetCurrentClassLogger();
            var fileReader = new FileReader(path,logger);

            var validationFunctionsList = new List<IValidator>
            {
                new NotNullValidation(logger)
            };

            var vendorID = "sunTrust";
            var invoiceDate = DateTime.Now;
            var invoiceNumber = "11124";
            var connectionString = "Server=DESKTOP-OH6TTHF\\SQLEXPRESS; Database=TWO;Trusted_Connection=True;User Id = DESKTOP-OH6TTHF\\CodePros";
            var jentry = EConnectHelper.DocumentBuilder(connectionString);
            var econnect = new TaPmTransaction(connectionString, jentry, logger, invoiceDate, vendorID, invoiceNumber);

            var wingateImporter = new WingateImporter(fileReader, validationFunctionsList, econnect, logger);
            wingateImporter.ImportWingate();
        }

    }
}
