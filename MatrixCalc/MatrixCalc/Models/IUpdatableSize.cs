using Xamarin.Forms;

namespace MatrixCalc.Model
{
    public interface IUpdatableSize
	{
        void UpdateFontSize();
        void UpdateFontSize(double childHeight, double childWidth);
        void UpdateSize(View parent);
        void UpdateSize(double height, double width);
    }
}

