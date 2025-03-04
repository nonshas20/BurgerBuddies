﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using popo.Model;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class OrderPopup : PopupPage
    {
        private int TransactionId;
        public OrderPopup(ProductModel selectedProduct, int transactionId)
        {
            InitializeComponent();
            this.selectedProduct = selectedProduct;
            NameLabel.Text = selectedProduct.Product_Name;
            StockLabel.Text = selectedProduct.Product_Stock.ToString();
            PriceLabel.Text = selectedProduct.Product_Cost.ToString();
            QtyEntry.TextChanged += QtyEntry_TextChanged;
            TransactionId = transactionId;
        }
        private ProductModel selectedProduct;
        private async void OnButtonCancel_Clicked(object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private void QtyEntry_TextChanged(object sender, System.EventArgs e)
        {
            int.TryParse(QtyEntry.Text, out int Qty);
            int.TryParse(PriceLabel.Text, out int Price);
            int Total = Qty * Price;
            string TotalString = Total.ToString();
            AmtLabel.Text = TotalString;
        }

        private async void AddToCart_Button(object sender, System.EventArgs e)
        {
            string ProductName = NameLabel.Text;
            string ProductStock = StockLabel.Text;
            string ProductPrice = PriceLabel.Text;
            string OrderQuantity = QtyEntry.Text;
            string OrderTotal = AmtLabel.Text;

            if (string.IsNullOrWhiteSpace(OrderQuantity))
            {
                await DisplayAlert("Invalid", "Enter Order Quantity!", "OK");
            }
            if (!int.TryParse(OrderQuantity, out int OrderAmt))
            {
                await DisplayAlert("Invalid", "Please enter a valid Order Quantity!", "OK");
            }
            else if (OrderAmt >= selectedProduct.Product_Stock)
            {
                await DisplayAlert("Invalid", "Ordered amount cannot be higher than the product stock!", "OK");
            }
            else
            {
                AddToCart();
            }
        }
        async void AddToCart()
        {

            if (int.TryParse(QtyEntry.Text, out int Qty) && int.TryParse(PriceLabel.Text, out int Price))
            {
                int Total = Qty * Price;
                OrderModel newOrder = new OrderModel
                {
                    Product_Name = NameLabel.Text,
                    Transaction_Id = TransactionId,
                    Product_Cost = Price,
                    Order_Qty = Qty,
                    Order_Amt = Total
                };
                /*
                var products = await App.ProductsDatabase.ReadProducts();

                List<ProductModel> productItems = new List<ProductModel>();

                foreach (var product in products)
                {
                    ProductModel productItem = new ProductModel
                    {
                        Product_Id = product.Product_Id,
                        Category_Id = product.Category_Id,
                        Product_Name = product.Product_Name,
                        Product_Cost = product.Product_Cost,
                        Product_Stock = product.Product_Stock
                    };
                    productItems.Add(productItem);
                }

                foreach(ProductModel product in productItems)
                {
                    if (product.Transaction_Id == newOrder.Transaction_Id)
                    {
                        product.Product_Stock = product.Product_Stock - newOrder.Order_Qty;
                        await App.ProductsDatabase.UpdateProductStock(product);
                    }
                }
                */



                await App.OrderedItemsDatabase.CreateOrder(newOrder);
                await DisplayAlert("Success", "Added To Cart", "OK");
                await Navigation.PushAsync(new POSOrderPage3(newOrder, TransactionId));
                await PopupNavigation.Instance.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for product cost or stock", "OK");
            }
        }
        /*async void UpdateProduct()
        {
            if (int.TryParse(NewStockEntry.Text, out int newProductStock) && int.TryParse(NewPriceEntry.Text, out int newProductPrice))
            {
                selectedProduct.Product_Name = NewNameEntry.Text;
                selectedProduct.Product_Stock = newProductStock;
                selectedProduct.Product_Cost = newProductPrice;
                await App.ProductsDatabase.UpdateProducts(selectedProduct);
                await DisplayAlert("Success", "Updated Product!", "OK");
                await PopupNavigation.Instance.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Invalid input for product cost or stock", "OK");
            }

        }*/
    }
    /*
    public class ProductItem
    {
        public int Product_Id { get; set; }
        public int Category_Id { get; set; }
        public int Transaction_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Cost { get; set; }
        public int Product_Stock { get; set; }
    }*/
}