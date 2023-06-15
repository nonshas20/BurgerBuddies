using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace popo.Database
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db; // Initializing the database
        
        public SQLiteHelper(string dbPath) 
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<LoginModel>(); // Create table based on Login Model
        }
        public Task<int> CreateLoginDetails (LoginModel loginDetails)
        {
            return db.InsertAsync(loginDetails); // Create or Insert Object passed to this
        }
        public Task<List<LoginModel>> ReadLoginDetails () 
        { 
            return db.Table<LoginModel>().ToListAsync(); // Reads all data from the Login Model
        }
        public Task<int> UpdateLoginDetails(LoginModel loginDetails)
        {
            return db.UpdateAsync(loginDetails); // Updates the database based on the object passed onto this
        }
        public Task<int> DeleteLoginDetails(LoginModel loginDetails)
        {
            return db.DeleteAsync(loginDetails); // Deletes from the database based on the object passed thru this
        }

    }
}
