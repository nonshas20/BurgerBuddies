﻿using popo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteItem : ContentPage //Category List for Deleting Products (navigates to DrinksPOS)
    {
        public DeleteItem()
        {
            InitializeComponent();

            CategoryCollectionView.BindingContext = this;
        }

        private async void EditItemBurger_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseItemInBurger());
        }

        private async void DrinksButton_Clicked(object sender, EventArgs e)
        {
            var selectedCategory = ((Xamarin.Forms.Button)sender).CommandParameter as CategoryModel;
            if (selectedCategory != null)
            {
                int selectedCategoryId = selectedCategory.Category_Id;
                await Navigation.PushAsync(new DrinksPOS(selectedCategoryId));
            }
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