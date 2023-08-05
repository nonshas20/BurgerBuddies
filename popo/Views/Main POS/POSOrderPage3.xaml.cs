using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using popo.Model;
using Rg.Plugins.Popup.Services;
using System.Transactions;
using System.Diagnostics;

namespace popo
{
    public partial class POSOrderPage3 : ContentPage
    {
        private int TransactionId;
        private OrderModel orders;
        public POSOrderPage3(OrderModel orders,int transactionId)
        {
            InitializeComponent();
            CategoryCollectionView.BindingContext = this;
            this.orders = orders;
            TransactionId = transactionId;
        }
        private async void ViewShoppingCart(object sender, EventArgs e)
        {
            if (orders != null)
            {
                await Navigation.PushAsync(new ViewShoppingCart2(orders, TransactionId));
            }
            else
            {
                await DisplayAlert("Invalid", "Please Add an item to cart first!", "Ok");
            }
        }
        private async void Category_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                CategoryModel category = button.BindingContext as CategoryModel;

                if (category != null)
                {
                    await Navigation.PushAsync(new POSOrderPage2(category, TransactionId));
                }
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CategoryCollectionView.ItemsSource = await App.CategoryDatabase.ReadCategory();
        }
    }
}
