using System;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class InputEntry : BaseEntry 
	{
        private Random random;
        private string lastNumber;

        public int Row { get; set; }
		public int Column { get; set; }
        public int LineId { get; set; }

        public InputEntry()
        { 
            random = new Random();
            Keyboard = Keyboard.Numeric;
            MaxLength = 3;
            Text = random.Next(0, 999).ToString();
            lastNumber = Text;

            TextChanged += UpdateResults;
            Unfocused += RestoreNumber;
            FontManager.UpdateFontDelegate += UpdateFontSize;
        }

        public void UpdateResults(object sender, TextChangedEventArgs e)
        {
            if (IsNumeric(e.NewTextValue))
            {
                Text = e.NewTextValue;
                UpdateResultsDelegate.UpdateResults();
            }
            else
            {
                lastNumber = e.OldTextValue;
            }

        }

        public void UpdateFontSize()
        {
            FontSize = Matrix.ChildHeight / 3.5;
        }

        public void GenerateNewValue()
        {
            Text = random.Next(0, 999).ToString();
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


        private void RestoreNumber(object sender, FocusEventArgs e)
        {
            if (Text == "")
                Text = lastNumber;

        }

        private bool SumMoreZero(string value)
        {
            int sum = 0;

            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            foreach (char c in value)
            {
                sum += (int)c;
            }

            if (sum <= 0)
            {
                return false;
            }

            return true;
        }
    }
}

