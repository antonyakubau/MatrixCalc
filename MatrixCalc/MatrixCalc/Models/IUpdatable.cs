using Xamarin.Forms;

namespace MatrixCalc.Models
{
    public interface IUpdatable
	{
        void UpdateFontSize();
        void UpdateFontSize(double childHeight, double childWidth);
        void UpdateSize(View parent);
        void UpdateSize(double height, double width);
    }
}