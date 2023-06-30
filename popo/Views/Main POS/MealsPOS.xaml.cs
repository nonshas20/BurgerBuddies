﻿using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace popo
{
    public partial class MealsPOS : ContentPage
    {

        public ObservableCollection<Product> Products { get; set; }

        public MealsPOS()
        {
            InitializeComponent();


            Products = new ObservableCollection<Product>
            {
                new Product { ProductName = "Chicken Adobo", Price = 150.00M, Stocks = 10, Quantity = 0 },
                new Product { ProductName = "Pork Sinigang", Price = 180.00M, Stocks = 8, Quantity = 0 },
                new Product { ProductName = "Beef Kare-Kare", Price = 220.00M, Stocks = 5, Quantity = 0 },
                new Product { ProductName = "Fish Escabeche", Price = 200.00M, Stocks = 6, Quantity = 0 },
                new Product { ProductName = "Vegetable Curry", Price = 170.00M, Stocks = 12, Quantity = 0 },
                // add more products here
            };

            BindingContext = this;
        }
    }


    public class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stocks { get; set; }
        public int Quantity { get; set; }
    }
}