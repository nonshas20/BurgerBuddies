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
    public partial class AddCategoryPage : ContentPage
    {
        public AddCategoryPage()
        {
            InitializeComponent();
        }

        private void AddMoreItemsButton_Clicked(object sender, System.EventArgs e)
        {
            // Add your logic to add more items
        }

        private void CancelButton_Clicked(object sender, System.EventArgs e)
        {
            // Navigate back to the previous page
            Navigation.PopAsync();
        }

        private void SaveButton_Clicked(object sender, System.EventArgs e)
        {
            // Add your logic to save the category and items
        }
    }
}