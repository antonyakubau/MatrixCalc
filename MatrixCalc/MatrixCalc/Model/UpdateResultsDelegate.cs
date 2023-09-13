using System;
using MatrixCalc.ViewModel;
using Xamarin.Forms.Shapes;

namespace MatrixCalc.Model
{
	public class UpdateResultsDelegate
	{
        public delegate void UpdateHandler();

        public static UpdateHandler UpdateResults;
    }
}

