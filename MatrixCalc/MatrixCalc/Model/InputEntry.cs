using System;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class InputEntry : BaseEntry 
	{
        private Random random = new Random();
        private string lastNumber;

        public int Row { get; protected set; }
		public int Column { get; protected set; }

        public InputEntry(int row, int column)
        { 
            Keyboard = Keyboard.Numeric;
            MaxLength = 3;
            Behaviors.Add(new InputTextBehavior());
            Text = random.Next(0, 999).ToString();
            lastNumber = Text;

            Row = row;
            Column = column;

            TextChanged += UpdateResults;
            Unfocused += RestoreNumber;
            FontManager.UpdateFontDelegate += UpdateFontSize;
        }

        public InputEntry(InputEntry oldInputEntry)
        {
            Keyboard = Keyboard.Numeric;
            MaxLength = 3;
            Behaviors.Add(new InputTextBehavior());
            Text = oldInputEntry.Text;
            lastNumber = Text;

            Row = oldInputEntry.Row;
            Column = oldInputEntry.Column;

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

