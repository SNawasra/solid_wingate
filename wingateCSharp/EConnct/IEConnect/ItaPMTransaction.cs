using Microsoft.Dynamics.GP.eConnect.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wingateCSharp.EConnct.IEConnect
{
    public interface ItaPMTransaction
    {
        bool TaPMTransactionInsert();
        taPMTransactionInsert SetTransactionLine(wingateSchema row);

    }
    public class taPmTransaction : ItaPMTransaction
    {
        public taPMTransactionInsert SetTransactionLine(wingateSchema row)
        {
            throw new NotImplementedException();
        }

        public bool TaPMTransactionInsert()
        {
            throw new NotImplementedException();
        }
    }
}
