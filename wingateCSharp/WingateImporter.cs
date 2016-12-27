using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wingateCSharp.EConnct;
using wingateCSharp.EConnct.IEConnect;
using wingateCSharp.Interfaces;

namespace wingateCSharp
{
    class WingateImporter
    {
        private Logger logger { get; set; }
        private IFileReader fileReader { get; set; }
        private List<IValidator> validatorList { get; set; }
        private ItaPMTransaction econnect { get; set; }

        public WingateImporter(
            IFileReader fileReader,
            List<IValidator> validatorList,
            ItaPMTransaction econnect,
            Logger logger)
        {
            if((fileReader != null) && (validatorList !=null) && (validatorList.Count != 0) && (econnect != null) && (logger !=null))
            {
                this.logger = logger;
                this.validatorList = validatorList;
                this.fileReader = fileReader;
                this.econnect = econnect;
            }
        }
        public  void ImportWingate()
        {
            List<wingateSchema> data = null;
            //var values = "";
            //if (fileReader.TryRead(out values))
            //{
            //    if (String.IsNullOrEmpty(values))
            //    {
            //        return;
            //    }

            //}
            //fileReader.TrySplit(values,out data);


            // fake split
            var splitRes = fileReader.TrySplit(out data);

            logger.Info("Start validation process");       
            foreach (var row in data)
            {
                foreach (var validatorFunction in validatorList)
                {
                    validatorFunction.Validator(row.SupplierName);
                    validatorFunction.Validator(row.TransactionLineCodingGLAccountNumber);
                }
            }
            logger.Info("End validation process");


            var calculatedStatement = StatmentHelper.lineAmountSummation(data);
            var statement = 40m;

            if (calculatedStatement != statement)
            {
                logger.Info("lineAmount not equal to the enterd one");
                return;
            }

            econnect.TaPMTransactionInsert(data);
            logger.Info("lineAmount equal to the enterd");
        }
    }
}
