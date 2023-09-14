using System;
using PropertyChanged;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class InputEntry : BaseEntry
	{
        private Random random = new Random();

		public int Row { get; set; }
		public int Column { get; set; }
        public int LineId { get; set; }


        private string number;
        public string NumericText
        {
            get { return number; }
            set
            {
                if (IsNumeric(value))
                {
                    this.number = value;
                }
            }
        }

        public InputEntry()
        {

            Keyboard = Keyboard.Numeric;
            MaxLength = 3;
            Text = random.Next(1, 999).ToString();
            TextChanged += UpdateResults;
            FontManager.UpdateFontDelegate += UpdateFontSize;
        }

        public static void UpdateResults(object sender, EventArgs e)
        {
            UpdateResultsDelegate.UpdateResults();
        }



        public void UpdateFontSize()
        {
            FontSize = Matrix.ChildHeight / 3.5;
        }

        private bool IsNumeric(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }


    }
}

