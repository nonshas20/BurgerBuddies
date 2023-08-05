using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using popo.Model;
using Rg.Plugins.Popup.Services;
using popo.Database;

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
            OrdersCollectionView.BindingContext = this;
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
                OrdersCollectionView.ItemsSource = await App.RecieptDatabase.ViewCart2(orders);
            }
            catch
            {

            }
        }

    }


}
