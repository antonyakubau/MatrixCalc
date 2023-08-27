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

        public MatrixPage()
        {
            InitializeComponent();
            BindingContext = new MatrixVM(this, MainMatrix);
        }
        
        public async void ShowMessage(int sum, int mult)
        {
            await DisplayAlert($"Results", $"Sum = {sum}\nMultiplication = " +
                $"{(mult > sizeof(int) ? mult : 0)}", "OK");
        }

        public async void ShowMessage()
        {
            await DisplayAlert($"Results", $"Sum = \nMultiplication = " +
                $"", "OK");
        }

        public async void ShowMessage(Exception ex)
        {
            await DisplayAlert($"Results", $"Sum = \nMultiplication = " +
                $"", "OK");
        }

        public async void ShowMessage(int sum)
        {
            await DisplayAlert($"Results", $"Sum = {sum}\nMultiplication = ", "OK");
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

    }
}

