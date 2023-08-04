using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using popo.Model;
using Rg.Plugins.Popup.Services;

namespace popo
{
    public partial class POSOrderPage2 : ContentPage
    {
        private int TransactionId;
        public POSOrderPage2(CategoryModel selectedCategory, int transactionId)
        {
            InitializeComponent();
            this.selectedCategory = selectedCategory;
            ProductCollectionView.BindingContext = this;
            TransactionId = transactionId;
        }
        private CategoryModel selectedCategory;

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                ProductModel product = button.BindingContext as ProductModel;
                if (product != null)
                {
                    await PopupNavigation.Instance.PushAsync(new OrderPopup(product, TransactionId));
                }
            }
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                ProductCollectionView.ItemsSource = await App.ProductsDatabase.FilterProducts(selectedCategory);
            }
            catch
            {

            }
        }
    }
}
