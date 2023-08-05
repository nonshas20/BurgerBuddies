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
            else if (CategoryName.Length >= 30)
            {
                await DisplayAlert("Invalid", "Category Name cannot be longer than 30 characters!", "OK");
            }
            else if (string.IsNullOrWhiteSpace(ItemName))
            {
                await DisplayAlert("Invalid", "Enter Product Name!", "OK");
            }
            else if (ItemName.Length >= 30)
            {
                await DisplayAlert("Invalid", "Product Name cannot be longer than 30 characters!", "OK");
            }
            else if (string.IsNullOrWhiteSpace(Price))
            {
                await DisplayAlert("Invalid", "Enter Product's Price!", "OK");
            }
            else if (string.IsNullOrWhiteSpace(Stocks))
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

            if (!int.TryParse(PriceEntry.Text, out int productCost))
            {
                await DisplayAlert("Invalid", "Please enter a valid Product Price!", "OK");
            }
            else if (productCost >= 999)
            {
                await DisplayAlert("Invalid", "Product Price cannot be higher than 999!", "OK");
            }
            else if (productCost <= 0)
            {
                await DisplayAlert("Invalid", "Product Price cannot be lower than 0!", "OK");
            }
            else if (!int.TryParse(StocksEntry.Text, out int productStock))
            {
                await DisplayAlert("Invalid", "Please enter a valid Product Stock!", "OK");
            }
            else if (productStock >= 999)
            {
                await DisplayAlert("Invalid", "Product Stock cannot be higher than 999!", "OK");
            }
            else if (productStock <= 0)
            {
                await DisplayAlert("Invalid", "Product Stock cannot be lower than 0!", "OK");
            }
            else
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
        }
    }
}