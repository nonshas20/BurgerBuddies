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
    public partial class POSOrderPage : ContentPage
    {
        private int TransactionId;
        public POSOrderPage(int transactionId)
        {
            InitializeComponent();
            CategoryCollectionView.BindingContext = this;
            TransactionId = transactionId;
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

        /*private async void ViewShoppingCart(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                OrderModel orders = button.BindingContext as OrderModel;
                if (orders != null)
                {
                    await Navigation.PushAsync(new ViewShoppingCart2(orders));
                }
            }
        }*/

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CategoryCollectionView.ItemsSource = await App.CategoryDatabase.ReadCategory();
        }
    }
}
