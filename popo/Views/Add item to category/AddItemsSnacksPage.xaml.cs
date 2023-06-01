using System;
using Xamarin.Forms;

namespace popo
{
    public partial class AddItemsSnacksPage : ContentPage
    {
        public AddItemsSnacksPage()
        {
            InitializeComponent();
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
