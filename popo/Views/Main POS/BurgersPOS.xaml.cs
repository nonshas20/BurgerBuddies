﻿using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using popo.Model;

namespace popo
{
    public partial class BurgersPOS : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; } //Variable for product list
        private int SelectedCategoryId;//Variable for the Selected Category from Main POS

        public BurgersPOS(int SelectedCategoryId)
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>
            {
                //Dito sasaluhin yung mga ibabato ni OnAppearing from ProductsDatabase
            };
            this.BindingContext = this;
            this.SelectedCategoryId = SelectedCategoryId;
        }

        private async void ViewOrderButton_Clicked(object sender, EventArgs e)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (Product product in Products)
            {
                if (product.Quantity > 0)
                {
                    OrderItem orderItem = new OrderItem
                    {
                        Item = product.ProductName,
                        Price = (double)product.Price,
                        Quantity = product.Quantity
                    };
                    orderItems.Add(orderItem);
                }
            }

            await Navigation.PushAsync(new ViewOrdersPage(orderItems));
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                List<ProductModel> productsList = await App.ProductsDatabase.ReadProducts();
                foreach (var productModel in productsList)
                {
                    if (productModel.Category_Id == SelectedCategoryId)
                    {
                        // Assuming there's a constructor or conversion method in the Product class to convert from ProductModel
                        Products.Add(new Product
                        {
                            ProductName = productModel.Product_Name,
                            Price = productModel.Product_Cost,
                            Stocks = productModel.Product_Stock,
                            Quantity = 0
                        });
                    }
                }
            }
            catch
            {

            }
        }

    }
}
