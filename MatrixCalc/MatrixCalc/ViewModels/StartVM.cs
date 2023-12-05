using System;
using Xamarin.Forms;

namespace MatrixCalc.ViewModels
{
    public class StartVM
    {
        public Command OpenMatrixPage { get; set; }
        public StartVM()
        {
            OpenMatrixPage = new Command(Open);
        }

        private void Open()
        {
            App.Current.MainPage.Navigation.PushAsync(new MatrixPage());
            
        }
    }
}

