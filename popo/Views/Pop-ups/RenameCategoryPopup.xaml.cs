using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RenameCategoryPopup : PopupPage
    {
        public RenameCategoryPopup(string currentName = null)
        {
            InitializeComponent();
            
        }

        private async void OnCancelClicked(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void OnSaveClicked(object sender, System.EventArgs e)
        {
            // Save the new name here
            string newName = NewNameEntry.Text;

            // Close the popup
            await PopupNavigation.Instance.PopAsync();
        }
    }
}