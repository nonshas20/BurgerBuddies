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
            db.CreateTableAsync<OrderedItemsModel>(); // Create table based on Login Model
        }
        public Task<int> CreateLoginDetails(OrderedItemsModel OrderedItems)
        {
            return db.InsertAsync(OrderedItems); // Create or Insert Object passed to this
        }
        public Task<List<OrderedItemsModel>> ReadLoginDetails()
        {
            return db.Table<OrderedItemsModel>().ToListAsync(); // Reads all data from the Login Model
        }
        public Task<int> UpdateLoginDetails(OrderedItemsModel OrderedItems)
        {
            return db.UpdateAsync(OrderedItems); // Updates the database based on the object passed onto this
        }
        public Task<int> DeleteLoginDetails(OrderedItemsModel OrderedItems)
        {
            return db.DeleteAsync(OrderedItems); // Deletes from the database based on the object passed thru this
        }

    }
}
