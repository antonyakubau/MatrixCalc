using System;
using System.Collections.Generic;
using MatrixCalc.ViewModels;
using MatrixCalc.Views;
using Xamarin.Forms;

namespace MatrixCalc
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}

