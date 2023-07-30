using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.UI.Views;
using System.Data.Common;
using System.IO;
using popo.Database;

namespace popo
{
    public partial class App : Application
    {
        private static SQLiteHelper LoginDb;
        public static SQLiteHelper loginDatabase
        {
            get
            {
                if(LoginDb == null)
                {
                    LoginDb = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "LoginDetails.db3")); // Login Details database location
                }
                return LoginDb;
            }
        }

        private static SQLiteHelper2 CategoryDb;
        public static SQLiteHelper2 CategoryDatabase
        {
            get
            {
                if (CategoryDb == null)
                {
                    CategoryDb = new SQLiteHelper2(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "CategoryDb.db3")); // Login Details database location
                }
                return CategoryDb;
            }
        }
        private static SQLiteHelper3 OrderedItemsDb;
        public static SQLiteHelper3 OrderedItemsDatabase
        {
            get
            {
                if (OrderedItemsDb == null)
                {
                    OrderedItemsDb = new SQLiteHelper3(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "OrderedItemsDb.db3")); // Login Details database location
                }
                return OrderedItemsDb;
            }
        }
        private static SQLiteHelper4 ProductsDb;
        public static SQLiteHelper4 ProductsDatabase
        {
            get
            {
                if (ProductsDb == null)
                {
                    ProductsDb = new SQLiteHelper4(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "ProductsDb.db3")); // Login Details database location
                }
                return ProductsDb;
            }
        }
        private static SQLiteHelper5 PurchasedOrderDb;
        public static SQLiteHelper5 PurchasedOrderDatabase
        {
            get
            {
                if (PurchasedOrderDb == null)
                {
                    PurchasedOrderDb = new SQLiteHelper5(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "PurchasedOrderDb.db3")); // Login Details database location
                }
                return PurchasedOrderDb;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainTabbedPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
