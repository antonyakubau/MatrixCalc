using System;
using MatrixCalc.ViewModel;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class GetInfoButton : BaseButton
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int LineId { get; set; }

        public GetInfoButton()
		{
            Text = "⋯";
            VerticalOptions = LayoutOptions.FillAndExpand;
            this.SetBinding(Button.CommandProperty, new Binding("GetInfo"));
            CommandParameter = LineId;
            FontManager.UpdateFontDelegate += UpdateFontSize;
        }

        public void UpdateFontSize()
        {
            FontSize = Matrix.ChildHeight / 2;
        }
    }
}

