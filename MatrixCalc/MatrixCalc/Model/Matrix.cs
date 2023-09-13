using System;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class Matrix : Grid
	{
        public static double ChildHeight { get; set; }
        public static double ChildWidth { get; set; }

        public Matrix()
        {
            ChildAdded += CalculateChildHeightWidth;
        }

        private void CalculateChildHeightWidth(object sender, EventArgs e)
        {
            ChildHeight = Children[0].Height;
            ChildWidth = Children[0].Width;
        }

        public void CalculateChildHeightWidth()
        {
        }


    }
}

