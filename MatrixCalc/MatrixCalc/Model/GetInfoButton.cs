using System;
using MatrixCalc.ViewModel;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class GetInfoButton : BaseButton
	{
		public static int LastLineId { get; set; }

		public int Row { get; protected set; }
		public int Column { get; protected set; }
		public int LineId { get; set; }

		public GetInfoButton(int row, int column)
		{
			Text = "⋯";
			VerticalOptions = LayoutOptions.FillAndExpand;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			SetBinding(Button.CommandProperty, new Binding("GetInfo"));

			Row = row;
			Column = column;
			LineId = LastLineId;
			CommandParameter = LineId;

			FontManager.UpdateFontDelegate += UpdateFontSize;
		}

		public GetInfoButton()
		{
		}

		public void UpdateFontSize()
		{
			FontSize = Matrix.ChildWidth / 2;
		}

		public void UpdateFontSize(double childHeight, double childWidth)
		{
			FontSize = childWidth / 2;
		}
	}
}

