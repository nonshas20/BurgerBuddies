using popo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using System.Transactions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePage : ContentPage

    {
        private int TransactionId;
        private int grandTotal;
        private int amountReceived;

        public ChangePage(int transactionId, int grandTotal)//(double grandTotal)
        {
            InitializeComponent();
            TransactionId = transactionId;
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                int grandTotal = await App.RecieptDatabase.CalculateGrandTotal(TransactionId);
                await App.TransactionDatabase.UpdateTransactions(TransactionId, grandTotal);
                AmountPayableLabel.Text = grandTotal.ToString("C", new CultureInfo("en-PH"));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
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
                amountReceived = int.Parse(AmountReceivedEntry.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-PH"));
                if (amountReceived < grandTotal)
                {
                    await DisplayAlert("Insufficient amount", "The amount received is less than the amount payable.", "OK");
                    return;
                }
                int change = amountReceived - grandTotal;
                await Navigation.PushAsync(new CompletedPage(grandTotal, change));
            }
            catch (FormatException)
            {
                await DisplayAlert("Invalid amount", "Please enter a valid amount.", "OK");
            }
        }
    }
}
