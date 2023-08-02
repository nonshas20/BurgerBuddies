using popo.Model;
using System;
using System.Collections.Generic;
using System.Globalization; // Add this namespace

using Xamarin.Forms;

namespace popo
{
    public partial class ViewOrdersPage : ContentPage
    {
        public ViewOrdersPage()
        {
            InitializeComponent();
        }

        private async void OnAddItems_Clicked(object sender, EventArgs e)
        {
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


    public class OrderItem
    {
        // Properties for an order item, including the item name, price, quantity, and subtotal
        public string Item { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get { return Price * Quantity; } }
    }
}