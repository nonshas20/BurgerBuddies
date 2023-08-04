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

        public async Task<List<TransactionModel>> ViewCart(OrderModel orderedItem)
        {
            var orders = await db.Table<TransactionModel>().ToListAsync();
            var filteredOrder = orders.Where(p => p.Transaction_Id == orderedItem.Transaction_Id).ToList();
            return filteredOrder;
        }

    }
}
