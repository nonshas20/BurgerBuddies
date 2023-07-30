using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteCategoryPage : ContentPage
    {
        public DeleteCategoryPage()
        {
            InitializeComponent();

            CategoryCollectionView.BindingContext = this;
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {

            await PopupNavigation.Instance.PushAsync(new DeletePopupPage());
        }

        public async void OnDeleteConfirmed(string categoryName)
        {
            // Perform the necessary actions to delete the category
            // For example, you can call a method or perform an API request to delete the category from your data source

            // Display a success message or navigate back to the previous page
            await DisplayAlert("Success", $"{categoryName} has been deleted.", "OK");
            await Navigation.PopAsync(); // Navigate back to the previous page
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                CategoryCollectionView.ItemsSource = await App.CategoryDatabase.ReadCategory();
            }
            catch
            {

            }
        }
    }
}