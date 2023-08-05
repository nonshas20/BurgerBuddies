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
                        "LoginDetails.db3"));
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
                        "CategoryDb.db3"));
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
                        "OrderedItemsDb.db3"));
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
                        "ProductsDb.db3"));
                }
                return ProductsDb;
            }
        }
        private static SQLiteHelper5 TransactionDb;
        public static SQLiteHelper5 TransactionDatabase
        {
            get
            {
                if (TransactionDb == null)
                {
                    TransactionDb = new SQLiteHelper5(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "TransactionDb.db3"));
                }
                return TransactionDb;
            }
        }
        private static SQLiteHelper6 RecieptDb;
        public static SQLiteHelper6 RecieptDatabase
        {
            get
            {
                if (RecieptDb == null)
                {
                    RecieptDb = new SQLiteHelper6(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "RecieptDb.db3"));
                }
                return RecieptDb;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new CompletedPage(1,1));
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
