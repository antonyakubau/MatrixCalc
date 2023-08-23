using System;
using Xamarin.Forms;

namespace MatrixCalc.ViewModel
{
    public class StartPageVM
    {
        public Command OpenMatrixPage { get; set; }
        public StartPageVM()
        {
            OpenMatrixPage = new Command(Open);
        }

        private void Open()
        {
            App.Current.MainPage.Navigation.PushAsync(new MatrixPage());
            
        }
    }
}

