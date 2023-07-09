using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace popo.Model
{
    public class CateogryModel
    {
        [PrimaryKey, AutoIncrement]
        public int Category_Id { get; set; }
        [Unique]
        public string Category_Name { get; set; }
    }
}
