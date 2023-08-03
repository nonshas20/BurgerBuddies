using popo.Model;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace popo
{
    public partial class AddOnsPOS : ContentPage //MainPOS
    {
        //private int qty = 0;

        private ObservableCollection<ProductModel> ProductsList { get; set; }
        public AddOnsPOS(CategoryModel selectedCategory)
        {
            InitializeComponent();
            this.selectedCategory = selectedCategory;

            ProductsList = new ObservableCollection<ProductModel>();
            ProductListView.ItemsSource = ProductsList;
            ProductListView.BindingContext = this;
        }

        private CategoryModel selectedCategory;

        private async void ViewOrderButton_Clicked(object sender, EventArgs e)
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
            // TESTING
            /*var viewOrdersPage = new ViewOrdersPage(orderedItems);
            viewOrdersPage.Disappearing += async (s, args) =>
            {
                await RefreshProductsList(); // Refresh the ProductsList when returning from ViewOrdersPage
            };//TESTING
            await Navigation.PushAsync(viewOrdersPage);*/
        }

        //TESTING
        /*private async Task RefreshProductsList()
        {
            var filteredProducts = await App.ProductsDatabase.FilterProducts(this.selectedCategory);
            ProductsList.Clear();
            foreach (var product in filteredProducts)
            {
                ProductsList.Add(product);
            }
        }*/
        //TESTING

        private void SubQty(object sender, EventArgs e)
        {
            if (ProductListView.SelectedItem is ProductModel selectedProduct && selectedProduct.Qty > 0)
            {
                selectedProduct.Qty--;
            }
        }
        private void AddQty(object sender, EventArgs e)
        {
            if (ProductListView.SelectedItem is ProductModel selectedProduct && selectedProduct.Qty != selectedProduct.Product_Stock)
            {
                selectedProduct.Qty++;
            }
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                // Update the ProductsList collection with filtered products
                var filteredProducts = await App.ProductsDatabase.FilterProducts(this.selectedCategory);
                ProductsList.Clear();
                foreach (var product in filteredProducts)
                {
                    ProductsList.Add(product);
                }
            }
            catch
            {
                
            }
        }
    }
}
