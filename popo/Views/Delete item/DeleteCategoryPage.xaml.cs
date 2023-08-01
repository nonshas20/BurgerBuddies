using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using popo.Model;
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
            if (sender is Button button)
            {
                CategoryModel category = button.BindingContext as CategoryModel;
                if (category != null)
                {
                    await PopupNavigation.Instance.PushAsync(new DeletePopupPage(category));
                }
            }
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