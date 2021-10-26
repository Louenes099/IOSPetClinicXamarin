using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aug27
{
    public partial class App : Application
    {
        static DBUser database;
        public static DBUser Database
        {
            get
            {
                if (database == null)
                {
                    database = new DBUser
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "user.db3"));
                }
                return database;
            }
        }

        static PetDB _petDatabase;
        public static PetDB _PetDatabase
        {
            get
            {
                if (_petDatabase == null)
                {
                    _petDatabase = new PetDB
                        (Path.Combine(Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData), "user.db3"));
                }
                return _petDatabase;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage((new Login()));
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
