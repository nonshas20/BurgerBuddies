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
            Button button = sender as Button;
            Grid parentGrid = button.Parent as Grid;
            Frame frame = parentGrid.Children[0] as Frame;
            Label label = frame.Content as Label;
            string currentName = label.Text;

            var renamePopup = new RenameCategoryPopup(currentName);
            await PopupNavigation.Instance.PushAsync(renamePopup);
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
