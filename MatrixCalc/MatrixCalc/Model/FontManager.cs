using System;
using MatrixCalc.ViewModel;
using System.Collections.Generic;

namespace MatrixCalc.Model
{
	public class FontManager
    {

        public delegate void FontDelegate(double childHeight, double childWidth);
        public static FontDelegate UpdateFontDelegate;

        public FontManager()
		{
            
        }
    }
}

