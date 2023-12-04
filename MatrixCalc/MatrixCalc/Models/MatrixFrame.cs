using System;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class MatrixFrame : Frame
	{
		IUpdatable _child;

		public MatrixFrame(IUpdatable child) 
		{
			_child = child;
			Content = (View)_child;
            BackgroundColor = Color.DarkBlue;
            Margin = 0;
            UpdateManager.UpdateFont += UpdatePadding;
        }

        public void UpdatePadding(double childHeight, double childWidth)
        {
            Padding = childHeight / 8;
            if (this.Content is BaseButton)
            {
                Padding = childHeight / 12;
                ((BaseButton)Content).BorderWidth = childHeight / 40;
            }
        }
    }
}

