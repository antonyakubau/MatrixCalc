using System;
using MatrixCalc.ViewModel;
using System.Collections.Generic;

namespace MatrixCalc.Model
{
	public class UpdateManager
    {
        public delegate void UpdateFontDelegate(double childHeight, double childWidth);
        public static UpdateFontDelegate UpdateFont;

        public delegate void UpdateResultsDelegate();
        public static UpdateResultsDelegate UpdateResults;
    }
}

