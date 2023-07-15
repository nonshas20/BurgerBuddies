using popo.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace popo.Database
{
    public class SQLiteHelper2
    {
        private readonly SQLiteAsyncConnection db; // Initializing the database

        public SQLiteHelper2(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<CategoryModel>(); // Create table based on Login Model
        }
        public Task<int> CreateLoginDetails(CategoryModel Category)
        {
            return db.InsertAsync(Category); // Create or Insert Object passed to this
        }
        public Task<List<CategoryModel>> ReadLoginDetails()
        {
            return db.Table<CategoryModel>().ToListAsync(); // Reads all data from the Login Model
        }
        public Task<int> UpdateLoginDetails(CategoryModel Category)
        {
            return db.UpdateAsync(Category); // Updates the database based on the object passed onto this
        }
        public Task<int> DeleteLoginDetails(CategoryModel Category)
        {
            return db.DeleteAsync(Category); // Deletes from the database based on the object passed thru this
        }

    }
}
