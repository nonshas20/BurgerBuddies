using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;

namespace popo
{
    public partial class BurgersPOS : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; }

        public BurgersPOS()
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>
            {
                new Product { ProductName = "PLB", Price = 30.00M, Stocks = 50, Quantity = 0 },
                new Product { ProductName = "BC", Price = 35.00M, Stocks = 30, Quantity = 0 },
                new Product { ProductName = "CB", Price = 25.00M, Stocks = 40, Quantity = 0 },
                new Product { ProductName = "CBC", Price = 45.00M, Stocks = 15, Quantity = 0 },
                new Product { ProductName = "CBCE", Price = 30.00M, Stocks = 50, Quantity = 0 },
                new Product { ProductName = "PB", Price = 30.00M, Stocks = 50, Quantity = 0 }
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
