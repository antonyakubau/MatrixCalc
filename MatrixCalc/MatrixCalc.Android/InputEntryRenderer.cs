using System;
using Android.Content;
using MatrixCalc.Droid;
using MatrixCalc.Model;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(InputEntry), typeof(InputEntryRenderer))]
namespace MatrixCalc.Droid
{
	public class InputEntryRenderer : EntryRenderer
	{
        public InputEntryRenderer(Context context) : base(context)
        {

        }  

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
            }
        }
    }
}

