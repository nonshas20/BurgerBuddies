using System;
using System.Collections.Generic;
using System.Text;

namespace popo.Model
{
    public class RecieptModel
    {
        public int Transaction_Id { get; set; }
        public int Order_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Cost { get; set; }
        public int Order_Qty { get; set; }
        public int Order_Amt { get; set; }
    }
}
