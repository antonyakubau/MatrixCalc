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
        public List<IMatrixInfo> DB_Matrices { get; set; }

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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _savedItemsVM.GetMatrices();
            collectionView.ItemsSource = _savedItemsVM.DbMatrices;
        }
    }
}

