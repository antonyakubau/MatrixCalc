using System;
namespace MatrixCalc.Model
{
	public interface IUpdatableFont
	{
        double FontSize { get; set; }
        double UpdateFontSize();
    }
}

