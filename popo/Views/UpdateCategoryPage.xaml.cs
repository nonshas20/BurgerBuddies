using popo.Model;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateCategoryPage : ContentPage
    {
        public UpdateCategoryPage()
        {
            InitializeComponent();

            CategoryCollectionView.BindingContext = this;
        }
            private async void RenameButton_Clicked(object sender, System.EventArgs e)
            {
                if (sender is Button button)
                {
                    CategoryModel category = button.BindingContext as CategoryModel;
                    if(category != null)
                    {
                        await PopupNavigation.Instance.PushAsync(new RenameCategoryPopup(category));
                    }
                }
            }
        /*
        private async void OnCategoryButtonClicked(object sender, EventArgs e) //Event Handler pag nagclick ng category buttons
        {
            if (sender is Button button)
            {
                CategoryModel category = button.BindingContext as CategoryModel;

                if (category != null)
                {
                    await Navigation.PushAsync(new AddItemsCategoryPage(category));
                }
            }
        }
         */

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
