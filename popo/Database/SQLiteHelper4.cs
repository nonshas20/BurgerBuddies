using popo.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popo.Database
{
    public class SQLiteHelper4
    {
        private readonly SQLiteAsyncConnection db; // Initializing the database

        public SQLiteHelper4(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<ProductModel>(); // Create table based on Login Model
        }
        public Task<int> CreateProducts(ProductModel Products)
        {
            return db.InsertAsync(Products); // Create or Insert Object passed to this
        }
        public Task<List<ProductModel>> ReadProducts()
        {
            return db.Table<ProductModel>().ToListAsync(); // Reads all data from the Login Model
        }

        public async Task<List<ProductModel>> FilterProducts(CategoryModel selectedCategory)
        {
            var products = await db.Table<ProductModel>().ToListAsync();
            var filteredProducts = products.Where(p => p.Category_Id == selectedCategory.Category_Id).ToList();
            return filteredProducts;
        }
        public Task<int> UpdateProducts(ProductModel Products)
        {
            return db.UpdateAsync(Products); // Updates the database based on the object passed onto this
        }
        public Task<int> DeleteProducts(ProductModel Products)
        {
            return db.DeleteAsync(Products); // Deletes from the database based on the object passed thru this
        }
    }
}
