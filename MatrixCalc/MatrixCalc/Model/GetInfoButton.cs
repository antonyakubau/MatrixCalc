using System;
using MatrixCalc.ViewModel;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class GetInfoButton : BaseButton, IUpdatableFont
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int LineId { get; set; }

        public GetInfoButton()
		{
            Text = "⋯";
            FontSize = 1;
            this.SetBinding(Button.CommandProperty, new Binding("GetInfo"));
            CommandParameter = LineId;

        }

        public double UpdateFontSize()
        {
            return Matrix.ChildHeight / 2;
        }
    }
}

