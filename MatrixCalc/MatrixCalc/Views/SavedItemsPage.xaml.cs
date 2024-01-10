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
    [AddINotifyPropertyChangedInterface]
	public partial class SavedItemsPage : ContentPage
    {
        private SavedItemsVM _savedItemsVM;
        private bool itemButtonPressed;
        private Stopwatch stopwatch = new Stopwatch();

		public SavedItemsPage(IMatrix mainMatrix)
		{
			InitializeComponent();

            _savedItemsVM = new SavedItemsVM(mainMatrix);
            BindingContext = _savedItemsVM;
            //collectionView.ItemsSource = _savedItemsVM.DbMatrices;//
        }

        async void ItemButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = _savedItemsVM.DbMatrices;
        }

        void ItemButton_Pressed(System.Object sender, System.EventArgs e)
        {
            stopwatch.Start();
            itemButtonPressed = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                if (stopwatch.Elapsed.TotalSeconds >= 0.5)
                {
                    StopTimer();
                    OpenItemOptions((int)((Button)sender).CommandParameter);
                }
                return itemButtonPressed;
            });

        }

        void ItemButton_Released(System.Object sender, System.EventArgs e)
        {
            if (stopwatch.Elapsed.TotalSeconds < 0.5)
            {
                StopTimer();
            }
        }

        private void StopTimer()
        {
            itemButtonPressed = false;
            stopwatch.Stop();
            stopwatch.Reset();
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

