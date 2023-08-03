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
        //private List<OrderItem> orderedItems = new List<OrderItem>();


        //public ObservableCollection<Transaction> Transactions { get; set; }
        /*private async void ShoppingCart_Tapped(object sender, EventArgs e)
        {
            List<OrderItem> orderedItems = new List<OrderItem>();

            foreach (ProductModel product in ProductsList)
            {
                if (product.Qty > 0)
                {
                    OrderItem orderItem = new OrderItem
                    {
                        Product_Id = product.Product_Id,
                        Item = product.Product_Name,
                        Price = product.Product_Cost,
                        Quantity = product.Qty
                    };
                    orderedItems.Add(orderItem);
                }
            }
            await Navigation.PushAsync(new ViewOrdersPage(orderedItems));
        }*/
        public MainTabbedPage()//List<ProductModel> productsList
        {
            InitializeComponent();
            //InitializeData();
            //this.BindingContext = this;
                                                //ProductsList = productsList;
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            CategoryCollectionView.BindingContext = this;
        }
        /*private void InitializeData()
        {
            // Sample data for transactions (you can replace this with your actual data)
            Transactions = new ObservableCollection<Transaction>
            {
                new Transaction { Date = DateTime.Now, TotalPrice = 0.00m},
                new Transaction { Date = DateTime.Now.AddDays(-1), TotalPrice = 0.00m},
                new Transaction { Date = DateTime.Now.AddDays(-2), TotalPrice = 0.00m},
                // Add more transactions here...
            };
        }*/

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
        
        //TESTING
        /*private async void AddOnsButton_Clicked(object sender, EventArgs e)
        {
            var selectedCategory = ((Xamarin.Forms.Button)sender).CommandParameter as CategoryModel;
            if (selectedCategory != null)
            {
                int selectedCategoryId = selectedCategory.Category_Id;
                await Navigation.PushAsync(new AddOnsPOS(selectedCategoryId));
            }

        }*/

        private async void AddOnsButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Xamarin.Forms.Button button)
            {
                CategoryModel category = button.BindingContext as CategoryModel;
                if (category != null)
                {
                    await Navigation.PushAsync(new AddOnsPOS(category));
                }
            }
        }
        //TESTING



        private async void ExitButton_Clicked(object sender, EventArgs e)
        {
            // Navigate back to the LoginPage
            //await Navigation.PopToRootAsync();
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
                CategoryCollectionView.ItemsSource = await App.CategoryDatabase.ReadCategory();
            }
            catch
            {

            }
        }
    }
}