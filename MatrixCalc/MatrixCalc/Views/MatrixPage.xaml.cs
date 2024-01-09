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
            await DisplayAlert($"Updated", null, "OK");
        }

        public async void ShowException(Exception exception)
        {
            await DisplayAlert($"Exception", $"{exception.Message}", "OK");
        }

        async void OpenButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SavedItemsPage(MainMatrix));
        }

        async void SaveButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var name = await DisplayPromptAsync
                ("Save file", null, "Save", "Cancel", "Enter file name", 20,
                Keyboard.Default, Convert.ToString(DateTime.Now.ToShortDateString()));

            if (name == "")
            {
                await DisplayAlert($"Enter file name", null, "OK");
                SaveButton_Clicked(sender, e);
            }
            else
            if (name != null)
            {
                _matrixVM.SaveButtonCommand.Execute(name);
            }
        }
    }
}

