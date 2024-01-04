using System;

namespace DB_CourseProject.Models
{
    public class BalanceHistory
    {
        public int TransactionId { get; set; }
        public int ClientId { get; set; }
        public int SumOfTransaction { get; set; }
        public string TypeOfTransaction { get; set; }
        public int OrderId { get; set; }

        public BalanceHistory(int transactionId, int sumOfTransaction, string typeOfTransaction, int orderId)
        {
            TransactionId = transactionId;
            SumOfTransaction = sumOfTransaction;
            TypeOfTransaction = typeOfTransaction;
            OrderId = orderId;
        }
    }
}
