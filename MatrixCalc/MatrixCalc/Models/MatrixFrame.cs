using System;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class MatrixFrame : Frame
	{
		IUpdatableSize _child;

		public MatrixFrame(IUpdatableSize child)
		{
			_child = child;
			Content = (View)_child;
            BackgroundColor = Color.YellowGreen;
			Padding = 1;
		}
	}
}

