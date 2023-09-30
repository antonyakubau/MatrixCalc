using System;
using Xamarin.Forms;
using static SQLite.TableMapping;
using Xamarin.Forms.Shapes;

namespace MatrixCalc.Model
{
    public class UpdateButton : BaseButton
    {
        public UpdateButton()
		{
			Text = "⟳";
            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            SetBinding(Button.CommandProperty, new Binding("UpdateFromButton"));

            FontManager.UpdateFontDelegate += UpdateFontSize;
        }

        public void UpdateFontSize()
        {
            FontSize = Matrix.ChildWidth / 2;
        }

    }
}

