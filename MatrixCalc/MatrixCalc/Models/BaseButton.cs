using System;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class BaseButton : Button
    {
		public BaseButton()
		{
			BackgroundColor = Color.DarkBlue;
			TextColor = Color.AliceBlue;
            BorderWidth = 2;
            BorderColor = Color.AliceBlue;
            Padding = 0;
            FontFamily = "OpenSansRegular";
            CornerRadius = 8;
			FontAttributes = FontAttributes.Bold;
        }
	}
}

