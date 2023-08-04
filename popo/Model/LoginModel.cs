using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace popo.Database
{
    public class LoginModel
    {
        [PrimaryKey,AutoIncrement]
        public int User_Id { get; set; }
        [Unique]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
