using popo.Database;
using popo.Model;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCategoryPage : ContentPage
    {
        public AddCategoryPage()
        {
            InitializeComponent();
        }

        private void AddMoreItemsButton_Clicked(object sender, EventArgs e)
        {
            // Add your logic to add more items
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            // Navigate back to the previous page
            Navigation.PopAsync();
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        { 
            string CategoryName = CategoryEntry.Text;
            string ItemName = ItemNameEntry.Text;
            string Price = PriceEntry.Text;
            string Stocks = StocksEntry.Text;

            if (string.IsNullOrWhiteSpace(CategoryName))
            {
                await DisplayAlert("Invalid", "Enter Category Name!", "OK");
            }
            if (string.IsNullOrWhiteSpace(ItemName))
            {
                await DisplayAlert("Invalid", "Enter Product Name!", "OK");
            }
            if (string.IsNullOrWhiteSpace(Price))
            {
                await DisplayAlert("Invalid", "Enter Product's Price!", "OK");
            }
            if (string.IsNullOrWhiteSpace(Stocks))
            {
                await DisplayAlert("Invalid", "Enter Product's Stock!", "OK");
            }

            else
            {
                AddCategoryAndProduct();
            }
        }
        async void AddCategoryAndProduct()
        {
            CategoryModel createdCategory = await App.CategoryDatabase.CreateCategory(new CategoryModel
            {
                Category_Name = CategoryEntry.Text
            });
            if (int.TryParse(PriceEntry.Text, out int productCost) && int.TryParse(StocksEntry.Text, out int productStock))
            {
                await App.ProductsDatabase.CreateProducts(new ProductModel
                {
                    Category_Id = createdCategory.Category_Id,
                    Product_Name = ItemNameEntry.Text,
                    Product_Cost = productCost,
                    Product_Stock = productStock
                });
                await DisplayAlert("Success", "Category and Product Added!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for product cost or stock", "OK");
            }
        }
    }
}