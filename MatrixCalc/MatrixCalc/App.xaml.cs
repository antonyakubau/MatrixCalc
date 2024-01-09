using System;
using System.IO;
using MatrixCalc.Models;
using MatrixCalc.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatrixCalc
{
    public partial class App : Application
    {
        static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Constants.DatabasePath);
                }
                return database;
            }
        }

        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MatrixPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

