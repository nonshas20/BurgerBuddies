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
            string CategoryName = CategoryEntry.Text.ToUpper();
            string ItemName = ItemNameEntry.Text.ToUpper(); 
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
            var existingCategory = await App.CategoryDatabase.GetCategoryByName(CategoryEntry.Text.ToUpper());
            var existingProduct = await App.ProductsDatabase.GetProductByName(ItemNameEntry.Text.ToUpper());

            // Check if the category name already exists
            if (existingCategory != null)
            {
                await DisplayAlert("Error", "Category with the same name already exists.", "OK");
                return;
            }
            // Check if the product name already exists
            if (existingProduct != null)
            {
                await DisplayAlert("Error", "Product with the same name already exists.", "OK");
                return;
            }
            // If both category and product names are unique, proceed to create the category and product
            if (int.TryParse(PriceEntry.Text, out int productCost) && int.TryParse(StocksEntry.Text, out int productStock))
            {
                if (productCost <= 0 || productStock <= 0)
                {
                    await DisplayAlert("Error", "Product Cost or Stock cannot be equal to or less than 0!", "OK");
                    return;
                }
                else
                {
                    // Create the category first
                    var newCategory = new CategoryModel
                    {
                        Category_Name = CategoryEntry.Text.ToUpper(),
                    };
                    await App.CategoryDatabase.CreateCategory(newCategory);

                    // Create the product using the newly created category's Category_Id
                    await App.ProductsDatabase.CreateProducts(new ProductModel
                    {
                        Category_Id = newCategory.Category_Id,
                        Product_Name = ItemNameEntry.Text.ToUpper(),
                        Product_Cost = productCost,
                        Product_Stock = productStock
                    });

                    await DisplayAlert("Success", "Category and Product Added!", "OK");

                    await Navigation.PushAsync(new MainTabbedPage());

                }
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for product cost or stock", "OK");
                return;
            }
        }


    }
}