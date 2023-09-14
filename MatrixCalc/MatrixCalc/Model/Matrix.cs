using System;
using MatrixCalc.ViewModel;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class Matrix : Grid
	{
        public static double ChildHeight { get; set; }
        public static double ChildWidth { get; set; }

        public Matrix()
        {
            SizeChanged += UpdateChildHeightWidth;
            LayoutChanged += UpdateChildHeightWidth;
        }

        private void UpdateChildHeightWidth(object sender, EventArgs e)
        {
            ChildHeight = Children[0].Height;
            ChildWidth = Children[0].Width;

            FontManager.UpdateFontDelegate();
        }

        public void CalculateChildHeightWidth()
        {
        }


    }
}

