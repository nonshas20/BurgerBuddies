using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace popo.Model
{
    public class PurchaseOrderModel
    {
        [PrimaryKey, AutoIncrement]
        public int POrderId { get; set; }
        [Unique]
        public string Payment_Mode { get; set; }
        [Unique]
        public string Order_Mode { get; set; }
        [Unique]
        public string Order_Status { get; set; }
        public DateTime Order_Date { get; set; }
        public int Order_Total { get; set; }
    }
}
