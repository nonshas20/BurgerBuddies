using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace popo.Model
{
    public class ProductModel: INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Product_Id { get; set; }
        [ForeignKey("CategoryModel")]
        public int Category_Id { get; set; }
        [ForeignKey("TransactionModel")]
        public int Transaction_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Cost { get; set; }
        public int Product_Stock { get; set; }

        //TESTING
        private int qty { get; set; }
        public int Qty
        {
            get { return qty; }
            set
            {
                if (qty != value)
                {
                    qty = value;
                    OnPropertyChanged(nameof(Qty)); // Notify property changed
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //TESTING
    }
}
