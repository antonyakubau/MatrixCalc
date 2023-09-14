using System;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class BaseEntry : Entry
	{
        public BaseEntry()
		{
			BackgroundColor = Color.LightSteelBlue;
			FontFamily = "OpenSansRegular";
			FontAttributes = FontAttributes.Bold;
			HorizontalTextAlignment = TextAlignment.Center;
			TextColor = Color.Black;
			
        }


	}
}

