using Microsoft.Dynamics.GP.eConnect.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wingateCSharp.EConnct.IEConnect
{
    interface ItaPMTransaction
    {
        bool TaPMTransactionInsert();
        taPMTransactionInsert SetTransactionLine(wingateSchema row);

    }
}
