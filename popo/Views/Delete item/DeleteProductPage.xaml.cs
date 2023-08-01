using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using popo.Model;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;

namespace popo
{
    public partial class DeleteProductPage: ContentPage
    {
        public DeleteProductPage(CategoryModel selectedCategory)
        {
            InitializeComponent();
            this.selectedCategory = selectedCategory;
            ProductCollectionView.BindingContext = this;
        }

        private CategoryModel selectedCategory;
        private async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                ProductModel product = button.BindingContext as ProductModel;
                if (product != null)
                {
                    await PopupNavigation.Instance.PushAsync(new DeletePopup_ItemPage(product));
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
