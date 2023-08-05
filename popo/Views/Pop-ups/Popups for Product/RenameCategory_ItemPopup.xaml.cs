using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using popo.Model;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class RenameCategory_ItemPopup : PopupPage
    {

        public RenameCategory_ItemPopup(ProductModel selectedProduct)
        {
            InitializeComponent();
            this.selectedProduct = selectedProduct;
            CurrentNameLabel.Text = selectedProduct.Product_Name;
            CurrentStockLabel.Text = selectedProduct.Product_Stock.ToString();
            CurrentPriceLabel.Text = selectedProduct.Product_Cost.ToString();
        }
        private ProductModel selectedProduct;
        private async void OnButtonCancel_Clicked(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void OnButtonSave_Clicked(object sender, System.EventArgs e)
        {
            string NewProductName = NewNameEntry.Text;
            string NewProductStock = NewStockEntry.Text;
            string NewProductPrice = NewPriceEntry.Text;

            if (string.IsNullOrWhiteSpace(NewProductName))
            {
                await DisplayAlert("Invalid", "Enter New Product's Name!", "OK");
            }
            else if (NewProductName.Length > 30)
            {
                await DisplayAlert("Invalid", "New Product Name cannot be longer than 30 characters!", "OK");
            }
            else if (string.IsNullOrWhiteSpace(NewProductStock))
            {
                await DisplayAlert("Invalid", "Enter New Product's Stock!", "OK");
            }
            else if (string.IsNullOrWhiteSpace(NewProductPrice))
            {
                await DisplayAlert("Invalid", "Enter New Product's Price!", "OK");
            }
            else
            {
                UpdateProduct();
            }
        }

        async void UpdateProduct()
        {

            if (!int.TryParse(NewPriceEntry.Text, out int NewProductCost))
            {
                await DisplayAlert("Invalid", "Please enter a valid Product Price!", "OK");
            }
            else if (NewProductCost >= 999)
            {
                await DisplayAlert("Invalid", "Product Price cannot be higher than 999!", "OK");
            }
            else if (NewProductCost <= 0)
            {
                await DisplayAlert("Invalid", "Product Price cannot be lower than 0!", "OK");
            }
            else if (!int.TryParse(NewStockEntry.Text, out int NewProductStock))
            {
                await DisplayAlert("Invalid", "Please enter a valid Product Stock!", "OK");
            }
            else if (NewProductStock >= 999)
            {
                await DisplayAlert("Invalid", "Product Stock cannot be higher than 999!", "OK");
            }
            else if (NewProductStock <= 0)
            {
                await DisplayAlert("Invalid", "Product Stock cannot be lower than 0!", "OK");
            }
            else
            {
                selectedProduct.Product_Name = NewNameEntry.Text;
                selectedProduct.Product_Stock = NewProductStock;
                selectedProduct.Product_Cost = NewProductCost;
                await App.ProductsDatabase.UpdateProducts(selectedProduct);
                await DisplayAlert("Success", "Updated Product!", "OK");
                await Navigation.PopAsync();
                await PopupNavigation.Instance.PopAsync();
            }

        }
    }
}