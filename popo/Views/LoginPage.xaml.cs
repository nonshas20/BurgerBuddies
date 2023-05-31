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

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }
            else
            {
                // Check the entered credentials
                if (username == "admin" && password == "admin")
                {
                    // Navigate to MainPage.xaml
                    await Navigation.PushAsync(new MainTabbedPage());

                }
                else
                {
                    // Show an error message or handle the incorrect credentials case
                    await DisplayAlert("Login Failed", "Invalid username or password", "OK");
                }
            }
        }
    }
    }