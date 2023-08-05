using popo.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popo.Database
{
    public class SQLiteHelper5
    {
        private readonly SQLiteAsyncConnection db; // Initializing the database

        public SQLiteHelper5(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<TransactionModel>(); // Create table based on Login Model
        }

        public Task<int> CreateTransaction(TransactionModel transaction)
        {
            return db.InsertAsync(transaction); // Create or Insert Object passed to this
        }

        public Task<List<TransactionModel>> ReadTransactions()
        {
            return db.Table<TransactionModel>().ToListAsync(); // Reads all data from the Login Model
        }

        /*public async Task<List<TransactionModel>> ViewCart(OrderModel orderedItem)
        {
            var orders = await db.Table<TransactionModel>().ToListAsync();
            var filteredOrder = orders.Where(p => p.Transaction_Id == orderedItem.Transaction_Id).ToList();
            return filteredOrder;
        }
        */

        /*
        public async Task<List<TransactionModel>> ViewCart(OrderModel order, int transaction_id)
        {
            // Get all transactions and orders from the database
            var transactions = await db.Table<TransactionModel>().ToListAsync();
            var orders = await db.Table<OrderModel>().ToListAsync();

            // Join transactions and orders based on the Transaction_Id
            var filteredTransactionOrders = transactions.Join(
                orders,
                transaction => transaction.Transaction_Id,
                ord => ord.Transaction_Id,
                (transaction, ord) => new { Transaction = transaction, Order = ord }
            );

            // Filter the joined data based on the provided transaction_id and the given order's Transaction_Id
            var filteredData = filteredTransactionOrders
                .Where(pair => pair.Transaction.Transaction_Id == transaction_id && pair.Order.Transaction_Id == order.Transaction_Id)
                .Select(pair => pair.Transaction)
                .ToList();

            return filteredData;
        }*/

        public async Task<int> UpdateTransactions(int transactionId, int grandTotal)
        {
            List<TransactionItem> transactionItems = new List<TransactionItem>();

            foreach (var transaction in transactionItems)
            {
                TransactionItem transactItem = new TransactionItem
                {
                    Transaction_Id = transaction.Transaction_Id,
                    Payment_Mode = transaction.Payment_Mode,
                    Order_Mode = transaction.Order_Mode,
                    Order_Status = transaction.Order_Status,
                    Date = transaction.Date,
                    Order_Total = transaction.Order_Total
                };
                transactionItems.Add(transactItem);
            }

            foreach (var Transact in transactionItems)
            {
                if (transactionId == Transact.Transaction_Id)
                {
                    Transact.Order_Total = grandTotal;
                }
            }

            return await db.UpdateAsync(transactionItems);
        }


    }
}
