using System;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class InputEntry : BaseEntry
	{
        private Random random = new Random();

		public int Row { get; set; }
		public int Column { get; set; }
        public int LineId { get; set; }
        public static double newFontSize { get; set; } = (double)NamedSize.Large * 6;


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
            FontSize = newFontSize;
            Text = random.Next(1, 999).ToString();
            TextChanged += UpdateResults;
        }

        public static void UpdateResults(object sender, EventArgs e)
        {
            UpdateResultsDelegate.UpdateResults();
        }

        public static void IncreaseFontSize()
        {
            newFontSize = Matrix.ChildWidth / 4;
        }


        public static void UpdateFontSize()
        {
            newFontSize = Matrix.ChildWidth / 4;
        }

        public static void DecreaseFontSize()
        {
            newFontSize = Matrix.ChildWidth / 4;
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

