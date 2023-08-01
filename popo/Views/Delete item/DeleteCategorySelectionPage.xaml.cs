using popo.Model;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteCategorySelectionPage : ContentPage //Category List for Deleting Products (navigates to DrinksPOS)
    {
        public DeleteCategorySelectionPage()
        {
            InitializeComponent();

            CategoryCollectionView.BindingContext = this;
        }

        private async void DrinksButton_Clicked(object sender, EventArgs e)
        {
            if(sender is Button button)
            {
                CategoryModel selectedCategory = button.BindingContext as CategoryModel;
                if(selectedCategory != null)
                {
                    await Navigation.PushAsync(new DeleteProductPage(selectedCategory));
                }
            }
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                CategoryCollectionView.ItemsSource = await App.CategoryDatabase.ReadCategory();
            }
            catch
            {

            }
        }
    }
}