using System.Globalization;
using Xamarin.Forms;
using System;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletedPage : ContentPage
    {
        public CompletedPage(double grandTotal, double change)
        {
            InitializeComponent();
            AmountPayableLabel.Text = grandTotal.ToString("C", new CultureInfo("en-PH"));
            ChangeLabel.Text = change.ToString("C", new CultureInfo("en-PH"));
        }
        private async void NewEntryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainTabbedPage());
        }
    }
}
