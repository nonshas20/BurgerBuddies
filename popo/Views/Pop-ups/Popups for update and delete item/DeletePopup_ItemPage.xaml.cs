using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using System;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Linq;
using popo.Model;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeletePopup_ItemPage : PopupPage
    {
        public DeletePopup_ItemPage(string currentName = null)
        {
            InitializeComponent();
            //CategoryNameLabel.Text = selectedCategory.Category_Name;
        }
        //private CategoryModel selectedCategory;
        private async void OnButtonNo_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void OnButtonYes_Clicked(object sender, EventArgs e)
        {
            /*
            await App.CategoryDatabase.DeleteCategory(selectedCategory);
            await DisplayAlert("Success", "Deleted Category", "OK");
            await PopupNavigation.Instance.PopAsync();
            **/
        }
    }
}
