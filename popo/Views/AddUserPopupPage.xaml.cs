﻿using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using System;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Linq;



namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUserPopupPage : ContentPage
    {
        public AddUserPopupPage()
        {
            InitializeComponent();
        }
        private async void AddUserButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new AddUserPopUpPageLEGIT());
        }


    }
}