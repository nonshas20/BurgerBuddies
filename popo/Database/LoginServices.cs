using popo.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace popo.Database
{
    public static class LoginServices
    {
        static SQLiteAsyncConnection db;
        // this shit below is used to call the db
        static async Task Init()
        {
            if(db != null)
            {
                return;
            }
            var dbpath = Path.Combine(FileSystem.AppDataDirectory,"LoginDB.db");
            db = new SQLiteAsyncConnection(dbpath);
            await db.CreateTableAsync<LoginModel>();
        }

        public static async Task AddUser(string username, string password)
        {
            await Init();
            var login = new LoginModel
            {
                Username = username,
                Password = password
            };
            var id = await db.InsertAsync(login);
        }

        public static async Task RemoveUser(int id)
        {
            await Init();
            await db.DeleteAsync<LoginModel>(id);
        }

        public static async Task<IEnumerable<LoginModel>> GetUser()
        {
            await Init();
            var login = await db.Table<LoginModel>().ToListAsync();
            return login;
        }
    }
}
