using System;
using System.Collections.Generic;
using MatrixCalc.ViewModels;
using MatrixCalc.Models;

using Xamarin.Forms;

namespace MatrixCalc.Views
{	
	public partial class SavedItemsPage : ContentPage
	{
		private SavedItemsVM _savedItemsVM;
		public SavedItemsPage()
		{
			InitializeComponent();
            _savedItemsVM = new SavedItemsVM();
            BindingContext = _savedItemsVM;
        }
	}
}

