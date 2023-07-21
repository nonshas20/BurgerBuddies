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

            var existingCategory = await App.CategoryDatabase.GetCategoryByName(CategoryEntry.Text);
            var existingProduct = await App.ProductsDatabase.GetProductByName(ItemNameEntry.Text);
            // Check if the createdCategory is null, which means a category with the same name already exists
            if (existingCategory != null )
            {
                await DisplayAlert("Error", "Category with the same name already exists.", "OK");
                return; // Exit the method if there was an error
            }
            if (existingProduct != null)
            {
                await DisplayAlert("Error", "Product with the same name already exists.", "OK");
                return; // Exit the method if there was an error
            }
            // If createdCategory is not null, meaning a category name doesn't exist
            else
            {
                if (int.TryParse(PriceEntry.Text, out int productCost) && int.TryParse(StocksEntry.Text, out int productStock))
                {
                    if(productCost <= 0 || productStock <= 0)
                    {
                        await DisplayAlert("Error", "Product Cost or Stock cannot be equal or less than 0!", "OK");
                    }
                    else
                    {
                        await App.ProductsDatabase.CreateProducts(new ProductModel
                        {
                            Category_Id = existingCategory.Category_Id,
                            Product_Name = ItemNameEntry.Text,
                            Product_Cost = productCost,
                            Product_Stock = productStock
                        });
                        await DisplayAlert("Success", "Category and Product Added!", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Invalid input for product cost or stock", "OK");
                }
            }

        }


    }
}