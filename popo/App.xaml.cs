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
        private static SQLiteHelper db;
        public static SQLiteHelper loginDatabase
        {
            get
            {
                if(db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "LoginDetails.db3")); // Login Details database location
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
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
