using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedPage : ContentPage
    {
        public CompletedPage(double change)
        {
            InitializeComponent();
            ChangeLabel.Text = change.ToString("C", new CultureInfo("en-PH"));
        }
    }
}