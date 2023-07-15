using popo.Model;
using SQLite;
using System;
using System.Collections.Generic;
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
            db.CreateTableAsync<PurchaseOrderModel>(); // Create table based on Login Model
        }
        public Task<int> CreatePurchasedOrders(PurchaseOrderModel PurchasedOrders)
        {
            return db.InsertAsync(PurchasedOrders); // Create or Insert Object passed to this
        }
        public Task<List<PurchaseOrderModel>> ReadPurchasedOrders()
        {
            return db.Table<PurchaseOrderModel>().ToListAsync(); // Reads all data from the Login Model
        }
        public Task<int> UpdatePurchasedOrders(PurchaseOrderModel PurchasedOrders)
        {
            return db.UpdateAsync(PurchasedOrders); // Updates the database based on the object passed onto this
        }
        public Task<int> DeletePurchasedOrders(PurchaseOrderModel PurchasedOrders)
        {
            return db.DeleteAsync(PurchasedOrders); // Deletes from the database based on the object passed thru this
        }

    }
}
