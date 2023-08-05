using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Collections.Generic;
using popo.Model;
using System.Threading.Tasks;
using System;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : Xamarin.Forms.TabbedPage

    {
        public MainTabbedPage()//List<ProductModel> productsList
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            HistoryListView.BindingContext = this;

            var OrderMode_List = new List<string>
            {
                "Dine-In",
                "Take-Out"
            };
            ModePicker.ItemsSource = OrderMode_List;
            var PaymentMethod_List = new List<string> 
            {
                "Cash",
                "G-Cash",
                "Credit"
            };
            PaymentPicker.ItemsSource = PaymentMethod_List;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                UpdateClock();
                return true; // True to continue the timer, false to stop it
            });
        }
        private void UpdateClock()
        {
            // Get the current date and time and update the Text property of the Clock label
            Device.BeginInvokeOnMainThread(() =>
            {
                DateTime now = DateTime.Now;
                string formattedDateTime = now.ToString("MM/dd/yyyy HH:mm:ss");
                Clock.Text = formattedDateTime;
            });
        }
        private async void ConfirmButton_Clicked(object sender, EventArgs e)
        {
            string Payment = PaymentPicker.SelectedItem as string;
            string OrderMode = ModePicker.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(Payment))
            {
                await DisplayAlert("Invalid", "Select Payment Method!", "OK");
            }
            else if (string.IsNullOrWhiteSpace(OrderMode))
            {
                await DisplayAlert("Invalid", "Select Order Mode!", "OK");
            }
            else
            {
                int generatedTransactionId = await CreateTransactionRecord();
                await DisplayAlert("Success", "Welcome To Burger Buddies!", "OK");
                await Navigation.PushAsync(new POSOrderPage(generatedTransactionId));
            }
        }

        async Task<int> CreateTransactionRecord()
        {
            TransactionModel transaction = new TransactionModel
            {
                Payment_Mode = PaymentPicker.SelectedItem as string,
                Order_Mode = ModePicker.SelectedItem as string,
                Order_Status = "Pending",
                Date = Clock.Text.ToString()
            };
            await App.TransactionDatabase.CreateTransaction(transaction);
            PaymentPicker.SelectedItem = null;
            ModePicker.SelectedItem = null;
            return transaction.Transaction_Id; // Assuming Transaction_Id is a property of the TransactionModel representing the primary key.
        }


        private async void ClearButton_Clicked(object sender, EventArgs e)
        {
            PaymentPicker.SelectedItem = null;
            ModePicker.SelectedItem = null;
        }

        private async void OnThreeDotsClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new ThreeDotPage());
        }

        private async void EditCategoryItemButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCategorySelectionPage());
        }
        private async void RemoveCategoryItemButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCategorySelectionPage());
        }
        
        private async void ExitButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void AddCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCategoryPage());
        }
        private async void UpdateCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCategoryPage());
        }
        
        private async void DeleteCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCategoryPage());
        }
        
        private async void AddItemButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategorySelectionPage());
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                //CategoryCollectionView.ItemsSource = await App.CategoryDatabase.ReadCategory();
                HistoryListView.ItemsSource = await App.TransactionDatabase.ReadTransactions();
            }
            catch
            {

            }
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  