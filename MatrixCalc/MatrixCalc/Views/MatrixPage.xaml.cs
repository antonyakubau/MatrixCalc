using System;
using System.Collections.Generic;
using System.Windows.Input;
using MatrixCalc.Models;
using MatrixCalc.ViewModels;
using PropertyChanged;
using Xamarin.Forms;

namespace MatrixCalc.Views
{
    [AddINotifyPropertyChangedInterface]
    public partial class MatrixPage : ContentPage
    {
        private MatrixVM _matrixVM;

        public MatrixPage()
        {
            InitializeComponent();
            _matrixVM = new MatrixVM(MainMatrix);
            BindingContext = _matrixVM;

            ShowDialogManager.ShowMatrixUpdated += ShowUpdated;
            ShowDialogManager.ShowMatrixMessege += ShowMessage;
            ExceptionManager.ExceptionMessege += ShowException;
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

