using System;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class BaseButton : Button
    {
		public BaseButton()
		{
			BackgroundColor = Color.DarkBlue;
			TextColor = Color.White;
			FontFamily = "OpenSansRegular";
            CornerRadius = 8;
			FontAttributes = FontAttributes.Bold;
        }
	}
}

