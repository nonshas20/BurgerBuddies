using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using popo.Model;
using Rg.Plugins.Popup.Services;
using System.Transactions;

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
        private async void Category_Clicked(object sender, EventArgs e) //Event Handler pag nagclick ng category buttons
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
            try
            {
                base.OnAppearing();
                CategoryCollectionView.ItemsSource = await App.CategoryDatabase.ReadCategory();
            }
            catch
            {

            }
        }
    }
}
