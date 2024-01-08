using System;
using System.Collections.Generic;
using MatrixCalc.ViewModels;
using MatrixCalc.Models;

using Xamarin.Forms;
using MatrixCalc.Models.Interfaces;

namespace MatrixCalc.Views
{	
	public partial class SavedItemsPage : ContentPage
	{
		private SavedItemsVM _savedItemsVM;
		public SavedItemsPage(IMatrix mainMatrix)
		{
			InitializeComponent();

            _savedItemsVM = new SavedItemsVM(mainMatrix);
            BindingContext = _savedItemsVM;
        }

        async void ItemButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetDB_MatrixAsync();
        }
    }
}

