using System;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class InputEntry : BaseEntry, IUpdatable
	{
		private string _lastNumber;

		public int Row { get; protected set; }
		public int Column { get; protected set; }

		public InputEntry(int row, int column)
		{
            Keyboard = Keyboard.Numeric;
			MaxLength = 3;
			Behaviors.Add(new InputTextBehavior());
			Text = new Random().Next(0, 999).ToString();
			_lastNumber = Text;

			Row = row;
			Column = column;

			TextChanged += UpdateResults;
			Unfocused += RestoreNumber;
			UpdateManager.UpdateFont += UpdateFontSize;
		}

		public InputEntry()
		{
		}

		public InputEntry(InputEntry oldInputEntry)
		{
			Keyboard = Keyboard.Numeric;
			MaxLength = 3;
			Behaviors.Add(new InputTextBehavior());
			Text = oldInputEntry.Text;
			_lastNumber = Text;
			
			VerticalOptions = LayoutOptions.FillAndExpand;
			HorizontalOptions = LayoutOptions.FillAndExpand;

			Row = oldInputEntry.Row;
			Column = oldInputEntry.Column;

			TextChanged += UpdateResults;
			Unfocused += RestoreNumber;
			UpdateManager.UpdateFont += UpdateFontSize;
		}

		public void UpdateResults(object sender, TextChangedEventArgs e)
		{
			if (IsNumeric(e.NewTextValue))
			{
				Text = e.NewTextValue;
				if (UpdateManager.UpdateResults != null)
				{
                    UpdateManager.UpdateResults();
				}
			}
			else
			{
				_lastNumber = e.OldTextValue;
			}

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
			if (Text == string.Empty)
				Text = _lastNumber;
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
	

	public static class InputEntryExtensions
    {
        public static string InRange(this string value, int lowerBound, int upperBound)
        {
            return new Random().Next(lowerBound, upperBound).ToString();
        }
    }

}
