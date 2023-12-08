﻿using System;
using MatrixCalc.Models;
using MatrixCalc.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatrixCalc
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            MainPage = new MatrixPage();
            //MainPage = new SavedItemsPage();
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

