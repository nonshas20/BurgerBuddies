using popo.Database;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUserPopUpPage : PopupPage
    {
        public AddUserPopUpPage()
        {
            InitializeComponent();
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            // Close the popup
            PopupNavigation.Instance.PopAsync();
        }

        async void OnConfirmClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            // Perform validation and add the user
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) 
            {
                await DisplayAlert("Invalid", "Blank or white space is invalid!","OK");
            }
            else
            {
                AddLoginDetails();
            }
        }
        async void AddLoginDetails()
        {
            await App.loginDatabase.CreateLoginDetails(new LoginModel
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            });
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
