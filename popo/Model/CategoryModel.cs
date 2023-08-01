using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace popo.Model
{
    public class CategoryModel
    {
        [PrimaryKey, AutoIncrement]
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
    }
}
