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
    public partial class Burgersinv : ContentPage
    {
        public Burgersinv()
        {
            InitializeComponent();

        }
        private async void ViewOrderButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewOrdersPage());
        }
    }
}