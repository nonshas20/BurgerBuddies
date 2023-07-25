using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace popo.Model
{
    public class CategoryModel : INotifyPropertyChanged
    {
        private int category_Id;
        [PrimaryKey, AutoIncrement]
        public int Category_Id
        {
            get { return category_Id; }
            set
            {
                if (category_Id != value)
                {
                    category_Id = value;
                    OnPropertyChanged();
                }
            }
        }

        private string category_Name;
        [Unique]
        public string Category_Name
        {
            get { return category_Name; }
            set
            {
                if (category_Name != value)
                {
                    category_Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
