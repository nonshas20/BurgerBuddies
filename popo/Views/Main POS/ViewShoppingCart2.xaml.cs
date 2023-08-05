using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using popo.Model;
using Rg.Plugins.Popup.Services;
using popo.Database;
using System.Diagnostics;

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
}
