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
    public partial class InventoryPage : ContentPage
    {
        public InventoryPage()
        {
            InitializeComponent();
        }
        private async void POSButton_CLicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void HistoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }
        private async void AddCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategorySelectionPage());
        }
        private async void UpdateCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCategoryPage());
        }
    }
}