using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace popo.Model
{
    public class ProductModel
    {
        [PrimaryKey, AutoIncrement]
        public int Product_Id { get; set; }
        [ForeignKey("CategoryModel")]
        public int Category_Id { get; set; }
        [Unique]
        public string Product_Name { get; set; }
        public int Product_Cost { get; set; }
        public string Product_Description { get; set; }
        public int Product_Stock { get; set; }
    }
}
