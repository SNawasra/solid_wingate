using System.Collections.Generic;


namespace wingateCSharp
{
    class StatmentHelper
    {
        public static decimal lineAmountSummation(List<wingateSchema> rows)
        {
            decimal totalStatement = 0 ;

            foreach(var row in rows)
            {
                totalStatement += row.TransactionLineAmount;
            }

            return totalStatement;
        }
    }
}
