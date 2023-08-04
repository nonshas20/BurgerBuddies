using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePage : ContentPage
    {
        private double grandTotal;
        private double amountReceived;

        public ChangePage()//(double grandTotal)
        {
            InitializeComponent();
            this.grandTotal = grandTotal;
            AmountPayableLabel.Text = grandTotal.ToString("C", new CultureInfo("en-PH"));
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string value = button.Text;
            AmountReceivedEntry.Text = value;
        }

        private void OnExactAmountButtonClicked(object sender, EventArgs e)
        {
            string amountPayable = AmountPayableLabel.Text;
            amountPayable = amountPayable.Replace("₱", "");
            AmountReceivedEntry.Text = amountPayable;
        }

        private async void OnProceedButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(AmountReceivedEntry.Text))
                {
                    await DisplayAlert("Invalid amount", "Please enter a valid amount.", "OK");
                    return;
                }
                amountReceived = double.Parse(AmountReceivedEntry.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-PH"));
                if (amountReceived < grandTotal)
                {
                    await DisplayAlert("Insufficient amount", "The amount received is less than the amount payable.", "OK");
                    return;
                }
                double change = amountReceived - grandTotal;
                await Navigation.PushAsync(new CompletedPage());//(grandTotal, change));
            }
            catch (FormatException)
            {
                await DisplayAlert("Invalid amount", "Please enter a valid amount.", "OK");
            }
        }
    }
}
