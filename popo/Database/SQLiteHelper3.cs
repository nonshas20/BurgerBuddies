using popo.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popo.Database
{
    public class SQLiteHelper3
    {
        private readonly SQLiteAsyncConnection db; // Initializing the database

        public SQLiteHelper3(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<OrderModel>(); // Create table based on Login Model
        }

        public Task<int> CreateOrder(OrderModel Orders)
        {
            return db.InsertAsync(Orders); // Create or Insert Object passed to this
        }

        public Task<List<OrderModel>> ReadOrders()
        {
            return db.Table<OrderModel>().ToListAsync(); // Reads all data from the Login Model
        }
        public async Task<List<OrderModel>> ViewCart(OrderModel orders)
        {
            // Get all orders from the database
            var allOrders = await db.Table<OrderModel>().ToListAsync();

            // Get all transactions from the database
            var transactions = await db.Table<TransactionModel>().ToListAsync();

            Debug.WriteLine("Order Count: " + allOrders.Count);
            Debug.WriteLine("Order Count: " + allOrders.Count);

            // Join orders and transactions based on the Transaction_Id
            var filteredOrders = allOrders.Join(
                transactions,
                order => order.Transaction_Id,
                transaction => transaction.Transaction_Id,
                (order, transaction) => new { Order = order, Transaction = transaction }
            );

            // Filter the joined data based on the provided orders' Transaction_Id
            var filteredData = filteredOrders
                .Where(pair => pair.Transaction.Transaction_Id == orders.Transaction_Id)
                .Select(pair => pair.Order)
                .ToList();

            return filteredData;
    }

    }
}
