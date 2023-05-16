using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void OnLoginClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            // Check the entered credentials
            if (username == "admin" && password == "admin")
            {
                // Navigate to MainPage.xaml
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                // Show an error message or handle the incorrect credentials case
                DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }
        }
    }
}