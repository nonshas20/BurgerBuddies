using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUserPopUpPageLEGIT : PopupPage
    {
        public AddUserPopUpPageLEGIT()
        {
            InitializeComponent();
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            // Close the popup
            PopupNavigation.Instance.PopAsync();
        }

        private void OnConfirmClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            // Perform validation and add the user

            // Close the popup
            PopupNavigation.Instance.PopAsync();
        }
    }
}
