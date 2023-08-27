using System;
using MatrixCalc.ViewModel;
using System.Collections.Generic;

namespace MatrixCalc.Model
{
	public class FontSize
    {
        private MatrixVM matrixPageVM;

        public List<InputEntry> EntryList { get; set; }
        public List<GetInfoButton> ButtonList { get; set; }

        public FontSize()
		{
        }

        public void UpdateFontSize()
        {
            //newFontSize = this.Width / 3;
        }
    }
}

