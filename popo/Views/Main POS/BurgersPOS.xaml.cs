using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Collections.Generic;
using popo.Model;
using Rg.Plugins.Popup.Services;

namespace popo
{
    public partial class BurgersPOS : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; }
        private int SelectedCategoryId;

        public BurgersPOS(int SelectedCategoryId)
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>();
            this.BindingContext = this;
            this.SelectedCategoryId = SelectedCategoryId;
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                List<ProductModel> productsList = await App.ProductsDatabase.ReadProducts();
                foreach (var productModel in productsList)
                {
                    if (productModel.Category_Id == SelectedCategoryId)
                    {
                        Products.Add(new Product
                        {
                            ProductName = productModel.Product_Name,
                            Price = productModel.Product_Cost,
                            Stocks = productModel.Product_Stock,
                            Quantity = 0
                        });
                    }
                }
            }
            catch
            {

            }
        }

        private async void RenameButton_Clicked(object sender, EventArgs e)
        {
            // Create the pop-up page instance
            var renamePopup = new RenameCategory_ItemPopup();

            // Show the pop-up
            await PopupNavigation.Instance.PushAsync(renamePopup);
        }
    }
}
