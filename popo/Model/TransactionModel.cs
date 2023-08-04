using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace popo.Model
{
    public class TransactionModel
    {
        [PrimaryKey, AutoIncrement]
        public int Transaction_Id { get; set; }
        public string Payment_Mode { get; set; }
        public string Order_Mode { get; set; }

        public string Order_Status { get; set; }
        public string Date { get; set; }
        public int Order_Total { get; set; } 
    }
}
