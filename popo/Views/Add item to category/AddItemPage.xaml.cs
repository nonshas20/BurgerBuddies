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

        
        private async void AddItemBurger_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemsBurgerPage());
        }
        

        private async void AddItemSandwiches_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemSandwichesPage());
        }
        
        private async void AddItemsMeals_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemsMealsPage());
        }

        private async void AddItemsSnacks_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemsSnacksPage());
        }
        
        private async void AddItemsDrinks_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemsDrinksPage());
        }
        private async void AddItemsSingleOrders_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemsSingleOrdersPage());
        }
        private async void AddItemsAddOnsPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemsAddOnsPage());
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