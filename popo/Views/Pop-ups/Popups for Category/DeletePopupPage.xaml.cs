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
    public partial class DeletePopupPage: PopupPage
    {
        public DeletePopupPage(CategoryModel selectedCategory)
        {
            InitializeComponent();
            this.selectedCategory = selectedCategory;
            CategoryNameLabel.Text = selectedCategory.Category_Name;
        }
        private CategoryModel selectedCategory;
        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            await App.CategoryDatabase.DeleteCategory(selectedCategory);
            await DisplayAlert("Success", "Deleted Category", "OK");
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
