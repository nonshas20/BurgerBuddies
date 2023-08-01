using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using popo.Model;
using Rg.Plugins.Popup.Services;

namespace popo
{
    public partial class EditProductPage : ContentPage
    {
        public EditProductPage(CategoryModel selectedCategory)
        {
            InitializeComponent();
            this.selectedCategory = selectedCategory;
            ProductCollectionView.BindingContext = this;
        }
        private CategoryModel selectedCategory;

        private async void RenameButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                ProductModel product = button.BindingContext as ProductModel;
                if (product != null)
                {
                    await PopupNavigation.Instance.PushAsync(new RenameCategory_ItemPopup(product));
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
