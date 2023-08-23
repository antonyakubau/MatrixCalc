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
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button));
            CornerRadius = 8;
			FontAttributes = FontAttributes.Bold;
        }
	}
}

