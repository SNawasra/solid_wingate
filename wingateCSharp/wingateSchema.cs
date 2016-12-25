using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wingateCSharp
{
    class wingateSchema
    {
        public wingateSchema()
        {

        }
        public wingateSchema(int rowId,
            string supplierName,
            string cardholderFirstName,
            string cardholderLastName,
            decimal transactionLineAmount,
            string transactionLineCodingGLAccountNumber,
            decimal amount, 
            string transactionNotes)
        {

            this.SupplierName = supplierName;
            this.CardholderFirstName = cardholderFirstName;
            this.CardholderLastName = cardholderLastName;
            this.TransactionLineAmount = transactionLineAmount;
            this.TransactionLineCodingGLAccountNumber = transactionLineCodingGLAccountNumber;
            this.Amount = amount;
            this.TransactionNotes = transactionNotes;
        }

        public int RowId { get; set; }
        public string SupplierName { get; set; }
        public string CardholderFirstName { get; set; }
        public string CardholderLastName { get; set; }
        public decimal TransactionLineAmount { get; set; }
        public string TransactionLineCodingGLAccountNumber{ get; set; }
        public decimal Amount { get; set; }
        public string TransactionNotes { get; set; }
    }
}
