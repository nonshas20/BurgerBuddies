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
        public Task<int> CreateCategory(CategoryModel Category)
        {
            return db.InsertAsync(Category).ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    return Category.Category_Id; // Return the ID of the newly created category
                }
                else
                {
                    throw task.Exception;
                }
            });
        }
        public Task<List<CategoryModel>> ReadCategory()
        {
            return db.Table<CategoryModel>().ToListAsync(); // Reads all data from the Login Model
        }
        public Task<int> UpdateCategory(CategoryModel Category)
        {
            return db.UpdateAsync(Category); // Updates the database based on the object passed onto this
        }
        public Task<int> DeleteCategory(CategoryModel Category)
        {
            return db.DeleteAsync(Category); // Deletes from the database based on the object passed thru this
        }

    }
}
