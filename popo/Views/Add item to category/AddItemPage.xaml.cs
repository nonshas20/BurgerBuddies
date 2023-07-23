using popo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();

            CategoryCollectionView.BindingContext = this;
        }

        private CategoryModel selectedCategory;//Declared selected category
        private async void AddItemCategory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemsCategoryPage(selectedCategory));//insert selected category sa AddItemsBurgerPage
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

        private async void OnCategoryButtonClicked(object sender, EventArgs e) //Event Handler pag nagclick ng category buttons
        {
            if (sender is Button button)
            {
                CategoryModel category = button.BindingContext as CategoryModel;

                if (category != null)
                {
                    await Navigation.PushAsync(new AddItemsCategoryPage(category));
                }
            }
        }

    }
}