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
    public partial class RenameCategory_ItemPopup : PopupPage
    {
        public RenameCategory_ItemPopup(string currentName = null)
        {
            InitializeComponent();
            CurrentNameLabel.Text = currentName;
        }

        private async void OnButtonCancel_Clicked(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void OnButtonSave_Clicked(object sender, System.EventArgs e)
        {




            // Close the popup
            await PopupNavigation.Instance.PopAsync();
        }
    }
}