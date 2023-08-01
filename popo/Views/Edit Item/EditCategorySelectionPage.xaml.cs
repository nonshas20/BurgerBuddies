using popo.Model;
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
    public partial class EditCategorySelectionPage : ContentPage //Category List for Updating/Renaming Products (navigates to BurgersPOS)
    {
        public EditCategorySelectionPage()
        {
            InitializeComponent();

            CategoryCollectionView.BindingContext = this;
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                CategoryModel selectedCategory = button.BindingContext as CategoryModel;
                if (selectedCategory != null)
                {
                    await Navigation.PushAsync(new EditProductPage(selectedCategory));
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