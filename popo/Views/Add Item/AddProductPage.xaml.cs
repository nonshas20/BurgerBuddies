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
            else if(ItemName.Length > 30)
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
                AddProductToCategory();
            }
        }

        async void AddProductToCategory()
        {
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
                    Category_Id = selectedCategory.Category_Id,
                    Product_Name = ItemNameEntry.Text,
                    Product_Cost = productCost,
                    Product_Stock = productStock
                });
                await DisplayAlert("Success", "Product Added!", "OK");
                await Navigation.PopAsync();
            }
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
