using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using popo.Model;

namespace popo
{
    public partial class DrinksPOS: ContentPage //EditPOS - Button List for Deleting Products
    {
        public ObservableCollection<Product> Products { get; set; } //Variable for product list
        private int SelectedCategoryId;//Variable for the Selected Category from EditPOS: Deleting Products

        public DrinksPOS(int SelectedCategoryId)
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>
            {
                //Dito sasaluhin yung mga ibabato ni OnAppearing from ProductsDatabase
            };
            this.BindingContext = this;
            this.SelectedCategoryId = SelectedCategoryId;
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
