using popo.Model;
using System;
using Xamarin.Forms;

namespace popo
{
    public partial class AddProductPage : ContentPage
    {
        public AddProductPage(CategoryModel selectedCategory)
        {
            InitializeComponent();
            this.selectedCategory = selectedCategory; //Dadalhin yung info ng selected category dito
            CategoryEntry.Text = selectedCategory.Category_Name;
        }

        private CategoryModel selectedCategory; //Declared selected category

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            string CategoryName = CategoryEntry.Text;
            string ItemName = ItemNameEntry.Text;
            string Price = PriceEntry.Text;
            string Stocks = StocksEntry.Text;
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
                AddProductToCategory();
            }
        }

        async void AddProductToCategory()
        {
            if (int.TryParse(PriceEntry.Text, out int productCost) && int.TryParse(StocksEntry.Text, out int productStock))
            {
                await App.ProductsDatabase.CreateProducts(new ProductModel
                {
                    Category_Id = selectedCategory.Category_Id,
                    Product_Name = ItemNameEntry.Text,
                    Product_Cost = productCost,
                    Product_Stock = productStock
                });

                await DisplayAlert("Success", "Product Added!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for product cost or stock", "OK");
            }
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
