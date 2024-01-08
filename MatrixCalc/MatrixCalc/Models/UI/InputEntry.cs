using System;
using Xamarin.Forms;

namespace MatrixCalc.Models
{
	public class InputEntry : BaseEntry, IUpdatable
	{
		private string _lastNumber;

		public int Row { get; protected set; }
		public int Column { get; protected set; }

        public InputEntry(int row, int column)
        {
            InitializeSettings();

			UpdateTextSafe(new Random().Next(0, 999).ToString());
			_lastNumber = Text;

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
			_lastNumber = Text;
			
			Row = oldInputEntry.Row;
			Column = oldInputEntry.Column;
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

        public void UpdateTextSafe(string text)
        {
            RemoveEvents();
            Text = text;
            AssignEvents();
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
            AssignEvents();
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

        private void AssignEvents()
        {
            TextChanged += UpdateResults;
            Unfocused += RestoreNumber;
            UpdateManager.UpdateFont += UpdateFontSize;
        }

        private void RemoveEvents()
        {
            TextChanged -= UpdateResults;
            Unfocused -= RestoreNumber;
            UpdateManager.UpdateFont -= UpdateFontSize;
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
