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
    public partial class AddItemsSingleOrdersPage : ContentPage
    {
        public AddItemsSingleOrdersPage()
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