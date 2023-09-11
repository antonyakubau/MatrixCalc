using System;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class UpdateButton : GetInfoButton
    {
		public UpdateButton()
		{
			Text = "⟳";
			SetBinding(Button.CommandProperty, new Binding("UpdateFromButton"));
        }
		
	}
}

