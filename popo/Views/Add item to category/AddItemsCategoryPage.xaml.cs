using popo.Model;
using System;
using Xamarin.Forms;

namespace popo
{
    public partial class AddItemsCategoryPage : ContentPage
    {

        private CategoryModel selectedCategory; //Declared selected category

        public AddItemsCategoryPage(CategoryModel selectedCategory)
        {
            InitializeComponent();
            this.selectedCategory = selectedCategory; //Dadalhin yung info ng selected category dito
            CategoryEntry.Text = selectedCategory.Category_Name;
            int x = selectedCategory.Category_Id;
        }

        


        private void AddMoreItemsButton_Clicked(object sender, EventArgs e)
        {
            // Create an instance of the ItemFieldsControl
            ItemFieldsControl itemFieldsControl = new ItemFieldsControl();

            // Add the ItemFieldsControl to the DynamicFieldsStackLayout
            DynamicFieldsStackLayout.Children.Add(itemFieldsControl);
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            // Navigate back
            await Navigation.PopAsync();
        }
    }
}
