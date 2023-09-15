using System;
using System.Collections.Generic;
using MatrixCalc.ViewModel;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class Matrix : Grid
	{
        public static double ChildHeight { get; set; }
        public static double ChildWidth { get; set; }

        public List<InputEntry> EntryList { get; set; }
        public List<GetInfoButton> ButtonList { get; set; }
        public List<List<int>> Lines { get; set; }

        public Matrix()
        {
            Lines = new List<List<int>>();

            SizeChanged += UpdateChildHeightWidth;
            LayoutChanged += UpdateChildHeightWidth;
        }

        private void UpdateChildHeightWidth(object sender, EventArgs e)
        {
            ChildHeight = Children[0].Height;
            ChildWidth = Children[0].Width;

            FontManager.UpdateFontDelegate();
        }

        public void AssignLines()
        {
            Lines.Clear();

            foreach (var button in ButtonList)
            {
                List<int> line = new List<int>();
                foreach (var entry in EntryList)
                {
                    if ((entry.Row == button.Row)
                        || (entry.Column == button.Column))
                    {
                        line.Add(Convert.ToInt32(entry.Text));
                    }

                }
                Lines.Add(line);
            }

        }
    }
}

