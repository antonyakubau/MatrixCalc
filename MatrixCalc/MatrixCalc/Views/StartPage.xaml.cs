using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MatrixCalc
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        void aboutButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MatrixPage());
            
        }
    }
}

