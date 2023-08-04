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

        public string Payment_Mode { get; set; }

        public string Order_Mode { get; set; }

        public string Order_Status { get; set; }
        public string Order_Date { get; set; }
        public double Order_Total { get; set; }
    }
}
