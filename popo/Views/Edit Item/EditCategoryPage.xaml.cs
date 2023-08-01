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
    public partial class EditCategoryPage : ContentPage
    {
        public EditCategoryPage()
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
