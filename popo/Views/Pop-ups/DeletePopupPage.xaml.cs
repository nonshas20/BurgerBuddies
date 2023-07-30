using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using System;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Linq;


namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeletePopupPage: PopupPage
    {
        public DeletePopupPage(string categoryName = null)
        {
            InitializeComponent();
            
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            // Perform the delete action
            // Pass the category name back to the DeleteCategoryPage
            var deleteCategoryPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault() as DeleteCategoryPage;
            deleteCategoryPage?.OnDeleteConfirmed(CategoryNameLabel.Text);

            await PopupNavigation.Instance.PopAsync();
        }
    }
}
