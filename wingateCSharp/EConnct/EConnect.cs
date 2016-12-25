using Microsoft.Dynamics.GP.eConnect.Serialization;
using NLog;
using System;
using System.Collections.Generic;

namespace wingateCSharp.EConnct
{
    class EConnect
    {
        private Logger logger { get; set; }

        public EConnect(Logger logger)
        {
            if (logger != null)
            {
                throw new Exception("Logs can't be null");
            }
            this.logger = logger;
        }

        public taPMTransactionInsert SetTransactionLine(int jeEntry, wingateSchema row, decimal lineSequence, DateTime date, string vendor, string invoiceNumber)
        {
            var line = new taPMTransactionInsert();
            var batch = "SunTrust" + DateTime.Now.ToString("MMyy");

            line.BACHNUMB = batch;
            line.VCHNUMWK = jeEntry.ToString();

            line.VENDORID = vendor;
            line.DOCNUMBR = invoiceNumber;

            line.DOCTYPE = 1;
            line.DOCDATE = date.ToShortDateString();

            return line;
        }

        // try to send insert the transaction to econnect and reurns the status of the insertion
        public bool TaPMTransactionInsert(int jeEntry, List<wingateSchema> rows, string connectionString, DateTime date, string vendor, string invoiceNumber)
        {
            var eConnect = new eConnectType();
            var pmArray = new List<PMTransactionType>();
            var lineSequence = 0m;

            logger.Info("Setting Transaction started");
            foreach (var row in rows) {
                lineSequence = (lineSequence + 16384m);
                var pmType = new PMTransactionType();
                var procInfo = new eConnectProcessInfo();
                procInfo.ProcTimeOut = "10000";
                pmType.eConnectProcessInfo = procInfo;
                var line = SetTransactionLine(jeEntry, row, lineSequence, date, vendor, invoiceNumber);
                pmType.taPMTransactionInsert = line;

                var dstItems = new List<taPMDistribution_ItemsTaPMDistribution>();
                var dstItem = new taPMDistribution_ItemsTaPMDistribution();

                dstItem.DOCTYPE = 1;
                dstItem.VCHRNMBR = jeEntry.ToString();
                dstItem.VENDORID = vendor;
                dstItem.DISTTYPE = 6;

                if (row.TransactionLineAmount < 0m)
                    dstItem.DEBITAMT = row.TransactionLineAmount;
                else
                    dstItem.CRDTAMNT = row.TransactionLineAmount;

                dstItem.DistRef = (EConnectHelper.GenerateDistributionRefrence(row));
                dstItems.Add(dstItem);
                pmType.taPMDistribution_Items = dstItems.ToArray();

                pmArray.Add(pmType);
                eConnect.PMTransactionType = pmArray.ToArray();
            }
            logger.Debug("Transaction setted successfully");

            string message = null;
            var memoryStream = EConnectHelper.XMLSerialize(eConnect);
            if (memoryStream != null)
            {
                if (EConnectHelper.TryeConnectEntry(memoryStream, connectionString, out message))
                    return true;

                else
                    return false;
            }

            return false;
        }
    }
}
