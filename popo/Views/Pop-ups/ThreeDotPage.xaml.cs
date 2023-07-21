using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace popo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThreeDotPage : PopupPage
    {
        public ThreeDotPage()
        {
            InitializeComponent();
        }
        public class ItemData
        {
            public string ItemName { get; set; }
            public int Quantity { get; set; }
            public string Price { get; set; }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            DateTimeLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy\nhh:mm tt");

            // Populate the ListView with sample data
            var itemsList = new ObservableCollection<ItemData>
        {
            new ItemData { ItemName = "Plain Burger", Quantity = 1, Price = "30php" },
            new ItemData { ItemName = "Silog", Quantity = 1, Price = "30php" },
            // Add more items as needed
        };

            ItemsListView.ItemsSource = itemsList;
        }

        private void OnCloseClicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}