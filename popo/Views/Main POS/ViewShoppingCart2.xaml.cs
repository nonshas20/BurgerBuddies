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
        public ViewShoppingCart2()
        {
            InitializeComponent();
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
            }
            catch
            {

            }
        }
    }
}
