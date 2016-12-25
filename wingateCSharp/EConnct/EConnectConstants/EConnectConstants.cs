using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wingateCSharp
{
    enum Series
    {
        All = 1,
        Financial = 2,
        Sales = 3,
        Purchasing = 4,
        Inventory = 5,
        Payroll = 6,
        Project = 7
    }
    enum TransactionType
    {
        Regular = 1,
        Reversing = 2
    }
    enum RateExpiration
    {
         None,
         Daily,
         Weekly,
         BiWeekly,
         Semiweekly,
         Monthly,
         Quarterly,
         Annually,
         Miscellaneous,
         None9 
    }
    enum TrxDefaultDate
    {
        ExactDate,
        NextDate,
        PreviousDate
    }
    enum RateCalculationMethod
    {
        Multiple = 1,
        Divide = 2
    }
    enum DateLimits
    {
        Unlimited,
        Limited
    }
    enum ReqTrx
    {
        False,
        True
    }
    enum LedgerID
    {
        Base = 1, 
        IFRS = 2,
        Local = 3

    }
    enum AdjTrx
    {
        False,
        True
    }
}
 