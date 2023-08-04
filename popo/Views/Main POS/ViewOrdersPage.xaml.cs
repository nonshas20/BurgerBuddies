using popo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization; // Add this namespace

using Xamarin.Forms;

namespace popo
{
    public partial class ViewOrdersPage : ContentPage
    {
        private CategoryModel selectedCategory; //Call the selected category from the db

        private ObservableCollection<ProductModel> ProductsList { get; set; } //For list of relevant products from db

        public ViewOrdersPage(List<OrderItem> orderItems, CategoryModel selectedCategory)
        {
            InitializeComponent();
            this.selectedCategory = selectedCategory;
            OrderListView.ItemsSource = orderItems;
            BindingContext = this;
            
        }

        private async void OnAddItems_Clicked(object sender, EventArgs e)
        {
            //OnItemsConfirmed?.Invoke(this, EventArgs.Empty);
            await Navigation.PopAsync();
        }
        private async void ConfirmButton_Clicked(object sender, EventArgs e)
        {
            // Get the grand total from the GrandTotalLabel
            double grandTotal = double.Parse(GrandTotalLabel.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-PH"));
            // Get relevant products from database
            var filteredProducts = await App.ProductsDatabase.FilterProducts(this.selectedCategory);
            ProductsList = new ObservableCollection<ProductModel>(filteredProducts);

            //List for ordered items
            List<OrderItem> orderedItems = new List<OrderItem>();

            foreach (var order in OrderListView.ItemsSource as List<OrderItem>)
            {
                OrderItem orderItem = new OrderItem
                {
                    Product_Id = order.Product_Id,
                    Item = order.Item,
                    Price = order.Price,
                    Quantity = order.Quantity
                };
                orderedItems.Add(orderItem);
            }

            foreach (var order in OrderListView.ItemsSource as List<OrderItem>)
            {
                foreach(var product in ProductsList)
                {
                    if(order.Product_Id == product.Product_Id) //Comparing the Product_Id from List of OrderItems to the List of FilteredProducts
                    {
                        product.Product_Stock = product.Product_Stock - order.Quantity; //Updating the Product_Stocks
                        //await App.ProductsDatabase.UpdateProductsStocks(product);//TEMPORARY SOLUTION - SANA GUMANA!!!
                        await App.ProductsDatabase.UpdateProductStock(product);
                    }
                }
            }
            //TESTING - Putting the order entry into Purchase db
            await App.PurchasedOrderDatabase.CreatePurchasedOrders(new PurchaseOrderModel
            {
                Payment_Mode = "", //???
                Order_Mode = "",//Dine-in? Take-away?
                Order_Status = "",//Complete? Pending? Failed?
                Order_Date = "",//Real-time date
                Order_Total = grandTotal//???
            });
            //TESTING


            // Navigate to the ChangePage and pass the grand total as a parameter
            await Navigation.PushAsync(new ChangePage(grandTotal));
        }
        
        
    }


    public class OrderItem //Temp storage for items pending to be confirmed (Should be passed into properties of PurchaseOrderModel)
    {
        // Properties for an order item, including the item name, price, quantity, and subtotal
        public int Product_Id { get; set; }
        public string Item { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get { return Price * Quantity; } }
    }
}