using popo.Model;
using SQLite;
using System;
using System.Collections.Generic;
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
    }
}
