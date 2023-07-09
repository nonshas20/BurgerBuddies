using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;

namespace popo
{
    public partial class AddOnsPOS: ContentPage
    {
        public ObservableCollection<Product> Products { get; set; }

        public AddOnsPOS()
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>
            {
                new Product { ProductName = "HOTDOG B1T1", Price = 30.00M, Stocks = 50, Quantity = 0 },
                new Product { ProductName = "HOTDOG W/ CHEESE B1T1", Price = 35.00M, Stocks = 30, Quantity = 0 },
                new Product { ProductName = "HOTDOG COLESLAW W/ CHEESE B1T1", Price = 25.00M, Stocks = 40, Quantity = 0 },
                new Product { ProductName = "CBC", Price = 45.00M, Stocks = 15, Quantity = 0 }
            };

            BindingContext = this;
        }

        private async void ViewOrderButton_Clicked(object sender, EventArgs e)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (Product product in Products)
            {
                if (product.Quantity > 0)
                {
                    OrderItem orderItem = new OrderItem
                    {
                        Item = product.ProductName,
                        Price = (double)product.Price,
                        Quantity = product.Quantity
                    };
                    orderItems.Add(orderItem);
                }
            }

            await Navigation.PushAsync(new ViewOrdersPage(orderItems));
        }
    }
}
