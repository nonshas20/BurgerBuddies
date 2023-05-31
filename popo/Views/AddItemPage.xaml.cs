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
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
        }
        
        private async void AddItemBurger_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemsBurgerPage());
        }
    }
}