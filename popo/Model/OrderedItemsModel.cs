using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace popo.Model
{
    public class OrderedItemsModel
    {
        [PrimaryKey, AutoIncrement]
        public int OrderedItems_Id { get; set; }
        [ForeignKey("PurchaseOrderModel")]
        public int POrderId { get; set; }
        [ForeignKey("ProductModel")]
        public int Product_Id { get; set; }
        public int Order_Quantity { get; set; }

    }
}
