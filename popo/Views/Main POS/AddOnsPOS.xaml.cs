using popo.Model;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace popo
{
    public partial class AddOnsPOS : ContentPage //MainPOS
    {
        private int qty = 0;
        public AddOnsPOS(CategoryModel selectedCategory)
        {
            InitializeComponent();
            this.selectedCategory = selectedCategory;
            ProductListView.BindingContext = this;
        }

        private CategoryModel selectedCategory;

        private async void ViewOrderButton_Clicked(object sender, EventArgs e)
        {
            /*List<OrderItem> orderItems = new List<OrderItem>();

            foreach (Product product in Products)
            {
                if (product.Quantity > 0)
                {
                    OrderItem orderItem = new OrderItem
                    {
                        Item = product.ProductName,
                        Price = (double)product.Price,
                        Quantity = product.Quantity
                    };
                    orderItems.Add(orderItem);
                }
            }

            await Navigation.PushAsync(new ViewOrdersPage(orderItems));*/
            if (sender is Button button)
            {
                ProductModel product = button.BindingContext as ProductModel;
                if (product != null)
                {
                    //await PopupNavigation.Instance.PushAsync(new DeletePopup_ItemPage(product));
                    await Navigation.PushAsync(new ViewOrdersPage());
                }
            }
        }

        private void SubQty(object sender, EventArgs e)
        {
            /*if (qty > 0)
            {
                Label quantityLabel = (Label)FindByName("QuantityLabel");
                qty--;
                quantityLabel.Text = qty.ToString();
                
            }
            else if(qty <= 0)
            {
                Label quantityLabel = (Label)FindByName("QuantityLabel");
                qty = 0;
                quantityLabel.Text = qty.ToString();
            }*/
        }
        private void AddQty(object sender, EventArgs e)
        {
            /*Label quantityLabel = (Label)FindByName("QuantityLabel");
            qty++;
            quantityLabel.Text = qty.ToString();*/
        
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                ProductListView.ItemsSource = await App.ProductsDatabase.FilterProducts(this.selectedCategory);
            }
            catch
            {
                
            }
        }
    }
}
