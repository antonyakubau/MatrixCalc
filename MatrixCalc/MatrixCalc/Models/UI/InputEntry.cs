using System;
using Xamarin.Forms;

namespace MatrixCalc.Models
{
	public class InputEntry : BaseEntry, IUpdatable
	{
		private string _lastNumericValue;

		public int Row { get; protected set; }
		public int Column { get; protected set; }

        public InputEntry(int row, int column)
        {
            InitializeSettings();

			UpdateTextSafe(new Random().Next(0, 999).ToString());
			_lastNumericValue = Text;

			Row = row;
			Column = column;
        }

        public InputEntry()
        {

        }

		public InputEntry(InputEntry oldInputEntry)
		{
            InitializeSettings();

			UpdateTextSafe(oldInputEntry.Text);
			_lastNumericValue = Text;
			
			Row = oldInputEntry.Row;
			Column = oldInputEntry.Column;
        }

		public void UpdateResults(object sender, TextChangedEventArgs e)
		{
			if (IsNumeric())
			{
                _lastNumericValue = Text;
                if (UpdateManager.UpdateResults != null)
				{
                    UpdateManager.UpdateResults();
				}
			}

		}

        public void UpdateTextSafe(string newText)
        {
            TextChanged -= UpdateResults;
            Text = newText;
            TextChanged += UpdateResults;
        }

        public void UpdateFontSize()
		{
			FontSize = Matrix.ChildWidth / 3;
		}

		public void UpdateFontSize(double childHeight, double childWidth)
		{
			FontSize = childWidth / 3;
		}

		public void UpdateSize(View parent)
        {
            HeightRequest = parent.Height;
            WidthRequest = parent.Height;
        }

        public void UpdateSize(double childHeight, double childWidth)
        {
            HeightRequest = childHeight;
            WidthRequest = childWidth;
        }

        public string GenerateNewValue()
		{
			return new Random().Next(0, 999).ToString();
		}


        private void InitializeSettings()
        {
            Keyboard = Keyboard.Numeric;
            MaxLength = 3;
            Behaviors.Add(new InputTextBehavior());

            TextChanged += UpdateResults;
            Unfocused += RestoreNumber;
            UpdateManager.UpdateFont += UpdateFontSize;
        }

        private bool IsNumeric()
		{
			if (string.IsNullOrEmpty(Text))
			{
				return false;
			}

			foreach (char c in Text)
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
			if (Text == string.Empty || !IsNumeric())
				UpdateTextSafe(_lastNumericValue);
		}

		private bool SumIsPositive(string value)
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

			if (sum < 0)
			{
				return false;
			}

			return true;
		}
    }
	

	public static class InputEntryExtensions
    {
        public static string InRange(this string value, int lowerBound, int upperBound)
        {
            return new Random().Next(lowerBound, upperBound).ToString();
        }
    }

}
