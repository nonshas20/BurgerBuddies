using popo.Model;
using System;
using System.Collections.Generic;
using System.Globalization; // Add this namespace

using Xamarin.Forms;

namespace popo
{
    public partial class ViewOrdersPage : ContentPage
    {
        private List<OrderItem> OrderItems { get; }
        public ViewOrdersPage(List<OrderItem> orderItems)
        {
            InitializeComponent();
            OrderListView.ItemsSource = orderItems;
            BindingContext = this;
        }

        //public event EventHandler OnItemsConfirmed;

        /*
        private double GetProductPrice(int productId)
        {
            // Implement the logic to get the product price based on the Product_Id
            // For example, you can fetch it from the database using the productId
            // Replace this return statement with your actual logic
            return 10.0;
        }*/

        private async void OnAddItems_Clicked(object sender, EventArgs e)
        {
            //OnItemsConfirmed?.Invoke(this, EventArgs.Empty);

            await Navigation.PopAsync();
        }
        private async void ConfirmButton_Clicked(object sender, EventArgs e)
        {
            // Get the grand total from the GrandTotalLabel
            double grandTotal = double.Parse(GrandTotalLabel.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-PH"));

            // Navigate to the ChangePage and pass the grand total as a parameter
            await Navigation.PushAsync(new ChangePage(grandTotal));
        }
        
        
    }


    public class OrderItem //Temp storage for items pending to be confirmed (Should be passed into properties of PurchaseOrderModel)
    {
        // Properties for an order item, including the item name, price, quantity, and subtotal
        public int Product_Id { get; set; }
        public string Item { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get { return Price * Quantity; } }
    }
}