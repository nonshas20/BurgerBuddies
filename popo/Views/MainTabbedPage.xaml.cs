using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Application = Xamarin.Forms.Application;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : Xamarin.Forms.TabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

        
        }
        private async void BurgersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BurgersPOS());
        }
        private async void MealsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MealsPOS());
        }
        
        private async void SandwichesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SandwichesPOS());
        }



        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            // Navigate back to the LoginPage
            Navigation.PopToRootAsync();
        }
        private async void HistoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }
        private async void InventoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InventoryPage());
        }
        private async void AddCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCategoryPage());
        }
        private async void UpdateCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateCategoryPage());
        }
        
        private async void DeleteCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCategoryPage());
        }
        
        private async void AddItemButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
        }


    }
}