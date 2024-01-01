using System;
using Xamarin.Forms;
using static SQLite.TableMapping;
using Xamarin.Forms.Shapes;

namespace MatrixCalc.Models
{
	public class UpdateButton : BaseButton, IUpdatable
	{
		public UpdateButton()
		{
			Text = "⟳";
			VerticalOptions = LayoutOptions.FillAndExpand;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			SetBinding(Button.CommandProperty, new Binding("UpdateFromButton"));

			UpdateManager.UpdateFont += UpdateFontSize;
		}

		public void UpdateFontSize()
		{
			FontSize = Matrix.ChildWidth / 2;
		}

		public void UpdateFontSize(double childHeight, double childWidth)
		{
			FontSize = childWidth / 2;
		}

        public void UpdateSize(View parent)
        {
            HeightRequest = parent.Height;
            WidthRequest = parent.Height;
        }

        public void UpdateSize(double childHeight, double childWidth)
        {
            HeightRequest = childHeight;
            WidthRequest = childWidth;
        }
    }
}

