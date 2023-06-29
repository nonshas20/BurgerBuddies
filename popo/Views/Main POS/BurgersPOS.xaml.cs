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
    public partial class BurgersPOS : ContentPage
    {
        public BurgersPOS()
        {
            InitializeComponent();

        }
        private async void ViewOrderButton_Clicked(object sender, EventArgs e)
        {
            
            List<OrderItem> orderItems = new List<OrderItem>
    {
        new OrderItem { Item = "PLB", Price = 30, Quantity = 2 },
        new OrderItem { Item = "BC", Price = 35, Quantity = 3 },
        new OrderItem { Item = "CB", Price = 40, Quantity = 1 }
    };

            await Navigation.PushAsync(new ViewOrdersPage(orderItems));
        }

    }
}