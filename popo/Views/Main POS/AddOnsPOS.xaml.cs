using popo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace popo
{
    public partial class AddOnsPOS : ContentPage //MainPOS
    {
        public ObservableCollection<Product> Products { get; set; } //Variable for product list
        private int SelectedCategoryId;//Variable for the Selected Category from Main POS

        public AddOnsPOS(int SelectedCategoryId)
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
                Products.Clear();
                //Call all categories and products in database
                List<CategoryModel> categoryList = await App.CategoryDatabase.ReadCategory();
                List<ProductModel> productsList = await App.ProductsDatabase.ReadProducts();

                string selectedCategoryName = string.Empty;

                foreach (var categoryModel in categoryList)
                {
                    if (categoryModel.Category_Id == SelectedCategoryId)
                    {
                        selectedCategoryName = categoryModel.Category_Name; // Get the selected category name
                        break; // No need to continue the loop once the selected category is found
                    }
                }

                foreach (var categoryModel in categoryList)
                {
                    if (categoryModel.Category_Id == SelectedCategoryId)
                    {
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
                }

                this.Title = selectedCategoryName;
            }
            catch
            {

            }
        }
    }
}
