using System;
using System.Collections.Generic;
using MatrixCalc.Model;
using MatrixCalc.ViewModel;
using PropertyChanged;
using Xamarin.Forms;

namespace MatrixCalc
{
    [AddINotifyPropertyChangedInterface]
    public partial class MatrixPage : ContentPage
    {
        private MatrixVM matrixVM;

        public delegate void ShowUpdateHandler();
        public static ShowUpdateHandler ShowMatrixUpdated;

        public MatrixPage()
        {
            InitializeComponent();
            matrixVM = new MatrixVM(this, MainMatrix);
            BindingContext = matrixVM;

            ShowMatrixUpdated = ShowUpdated;
            ExceptionManager.ExceptionMessege = ShowException;
        }

        public async void ShowMessage(int sum, int min, int max, int everage)
        {
            await DisplayAlert(
                $"Results",
                $"Sum = {sum}\n" +
                $"Min = {min}\n" +
                $"Max = {max}\n" +
                $"Everage = {everage}"
                , "OK");
        }

        public async void ShowUpdated()
        {
            await DisplayAlert($"Updated", "", "OK");
        }

        public async void ShowException(Exception exception)
        {
            await DisplayAlert($"Exception", $"{exception.Message}", "OK");
        }
    }
}

