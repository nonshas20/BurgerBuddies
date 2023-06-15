using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace popo.Database
{
    public class LoginModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
