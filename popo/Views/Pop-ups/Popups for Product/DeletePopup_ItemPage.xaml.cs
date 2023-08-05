using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using System;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Linq;
using popo.Model;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeletePopup_ItemPage : PopupPage
    {
        public DeletePopup_ItemPage(ProductModel selectedProduct)
        {
            InitializeComponent();
            this.selectedProduct = selectedProduct;
            CategoryNameLabel.Text = selectedProduct.Product_Name;
        }

        private ProductModel selectedProduct;
        private async void OnButtonNo_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void OnButtonYes_Clicked(object sender, EventArgs e)
        {
            await App.ProductsDatabase.DeleteProducts(selectedProduct);
            await DisplayAlert("Success", "Deleted Product", "OK");
            await Navigation.PopAsync();
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
