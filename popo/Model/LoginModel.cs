using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace popo.Model
{
    public class LoginModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(16), NotNull]
        public string Username { get; set; }
        [MaxLength(16), NotNull]
        public string Password { get; set; }
        
    }
}
