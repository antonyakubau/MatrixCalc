using System;
using MatrixCalc.ViewModel;
using MatrixCalc.Model.MatrixInterfaces;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class GetInfoButton : BaseButton, IMatrixButton
    {

        public int Row { get; set; }
        public int Column { get; set; }
        public int LineId { get; set; }
        public static double newFontSize { get; set; } = (double)NamedSize.Large * 10;

        public GetInfoButton()
		{
            Text = "⋯";
            FontSize = newFontSize;
            this.SetBinding(Button.CommandProperty, new Binding("GetInfo"));
            CommandParameter = LineId;

        }

        public static void IncreaseFontSize()
        {
            newFontSize += 10;
        }

        public static void DecreaseFontSize()
        {
            newFontSize -= 10;
        }

    }
}

