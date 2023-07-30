using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

using Rg.Plugins.Popup.Services;
using Application = Xamarin.Forms.Application;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Diagnostics;
using popo;
using popo.Model;

namespace popo
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : Xamarin.Forms.TabbedPage

    {
        public ObservableCollection<Transaction> Transactions { get; set; }

        public MainTabbedPage()
        {
            InitializeComponent();
            InitializeData();
            this.BindingContext = this;

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            CategoryCollectionView.BindingContext = this;
        }
        private void InitializeData()
        {
            // Sample data for transactions (you can replace this with your actual data)
            Transactions = new ObservableCollection<Transaction>
        {
            new Transaction { Date = DateTime.Now, TotalPrice = 0.00m},
            new Transaction { Date = DateTime.Now.AddDays(-1), TotalPrice = 0.00m},
            new Transaction { Date = DateTime.Now.AddDays(-2), TotalPrice = 0.00m},
            // Add more transactions here...
        };
        }



        /*private async void BurgersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BurgersPOS());
        }*/
        private async void MealsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MealsPOS());
        }
        
        private async void SandwichesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SandwichesPOS());
        }
        
        private async void SnacksButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SnacksPOS());
        }

        private async void OnThreeDotsClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new ThreeDotPage());
        }

        private async void EditCategoryItemButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Edit_Category_ItemPage());
        }
        private async void RemoveCategoryItemButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteItem());
        }
        
        //TESTING
        private async void AddOnsButton_Clicked(object sender, EventArgs e)
        {
            var selectedCategory = ((Xamarin.Forms.Button)sender).CommandParameter as CategoryModel;
            if (selectedCategory != null)
            {
                int selectedCategoryId = selectedCategory.Category_Id;
                await Navigation.PushAsync(new AddOnsPOS(selectedCategoryId));
            }
        }
        //TESTING
        private async void DrinksButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DrinksPOS());
        }

        private async void SingleOrdersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SingleOrderPOS());
        }



        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            // Navigate back to the LoginPage
            Navigation.PopToRootAsync();
        }
        private async void HistoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }
        private async void InventoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InventoryPage());
        }
        private async void AddCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCategoryPage());
        }
        private async void UpdateCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateCategoryPage());
        }
        
        private async void DeleteCategoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCategoryPage());
        }
        
        private async void AddItemButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
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