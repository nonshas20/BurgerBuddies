using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using popo.Model;
using Rg.Plugins.Popup.Services;
using popo.Database;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;
using SQLite;

namespace popo
{
    public partial class ViewShoppingCart2 : ContentPage
    {
        private int TransactionId;
        private OrderModel orders;

        public ViewShoppingCart2(OrderModel orders, int transactionId)
        {
            InitializeComponent();
            TransactionId = transactionId;
            this.orders = orders; // Make sure to set the class-level 'orders' variable.
              // No need to set OrdersCollectionView.BindingContext here since you are setting the ItemsSource in OnAppearing.
        }


        private async void CloseButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                var recieptModels = await App.RecieptDatabase.ViewCart2(orders);
                OrdersCollectionView.ItemsSource = new ObservableCollection<RecieptModel>(recieptModels);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public class OrderItem //Temp storage for items pending to be confirmed (Should be passed into properties of PurchaseOrderModel)
    {
        // Properties for an order item, including the item name, price, quantity, and subtotal
        public int Order_Id { get; set; }
        public int Transaction_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Cost { get; set; }
        public int Order_Qty { get; set; }
        public int Order_Amt { get; set; }
    }

    public class TransactionItem
    {
        public int Transaction_Id { get; set; }
        public string Payment_Mode { get; set; }
        public string Order_Mode { get; set; }

        public string Order_Status { get; set; }
        public string Date { get; set; }
        public int Order_Total { get; set; }
    }

}
