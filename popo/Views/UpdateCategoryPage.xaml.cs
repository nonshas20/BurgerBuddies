using Rg.Plugins.Popup.Services;
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
            
            await PopupNavigation.Instance.PushAsync(new RenameCategoryPopup());
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
