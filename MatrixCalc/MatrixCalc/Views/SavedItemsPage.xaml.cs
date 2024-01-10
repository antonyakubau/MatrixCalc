using System;
using System.Collections.Generic;
using MatrixCalc.ViewModels;
using MatrixCalc.Models;

using Xamarin.Forms;
using MatrixCalc.Models.Interfaces;
using System.Diagnostics;
using System.Text;
using PropertyChanged;

namespace MatrixCalc.Views
{
	public partial class SavedItemsPage : ContentPage
    {
        private SavedItemsVM _savedItemsVM;
        private bool _itemButtonPressed;
        private Stopwatch _stopwatch;

		public SavedItemsPage(IMatrix mainMatrix)
		{
			InitializeComponent();
            _stopwatch = new Stopwatch();
            _savedItemsVM = new SavedItemsVM(mainMatrix);
            BindingContext = _savedItemsVM;
            //collectionView.ItemsSource = _savedItemsVM.DbMatrices;//
        }

        async void ItemButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        void ItemButton_Pressed(System.Object sender, System.EventArgs e)
        {
            _stopwatch.Start();
            _itemButtonPressed = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                if (_stopwatch.Elapsed.TotalSeconds >= 0.5)
                {
                    StopTimer();
                    OpenItemOptions((int)((Button)sender).CommandParameter);
                }
                return _itemButtonPressed;
            });

        }

        void ItemButton_Released(System.Object sender, System.EventArgs e)
        {
            if (_stopwatch.Elapsed.TotalSeconds < 0.5)
            {
                StopTimer();
            }
        }

        private void StopTimer()
        {
            _itemButtonPressed = false;
            _stopwatch.Stop();
            _stopwatch.Reset();
        }

        private async void OpenItemOptions(int id)
        {
            const string deleteOption = "Delete";

            var result = await DisplayActionSheet("Options", null, null, deleteOption);
            switch (result)
            {
                case deleteOption:
                    _savedItemsVM.DeleteSavedMatrixCommand.Execute(id);
                    break;
                default:
                    break;
            }
        }
    }
}

