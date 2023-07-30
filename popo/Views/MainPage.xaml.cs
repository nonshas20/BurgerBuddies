using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace popo
{
    

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();

        }
        /*private async void BurgersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BurgersPOS());
        }*/
        private async void MealsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MealsPOS());
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

    }
}
