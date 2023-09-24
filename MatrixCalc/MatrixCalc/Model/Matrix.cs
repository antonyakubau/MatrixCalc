using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace MatrixCalc.Model
{
	public class Matrix : Grid
	{
		public static double ChildHeight { get; set; }
		public static double ChildWidth { get; set; }

		public List<InputEntry> OldEntryList { get; private set; }
		public List<InputEntry> EntryList { get; private set; }
		public List<GetInfoButton> ButtonList { get; private set; }
		public List<List<InputEntry>> Lines { get; private set; }

		public Matrix()
		{
			EntryList = new List<InputEntry>();
			ButtonList = new List<GetInfoButton>();
			Lines = new List<List<InputEntry>>();

			SizeChanged += UpdateChildHeightWidth;
			LayoutChanged += UpdateChildHeightWidth;
		}
		

		public void UpdateValues()
		{
			foreach (var entry in EntryList)
			{
				entry.GenerateNewValue();
			}
		}

		public void UpdateMatrix(int currentMatrixDimension)
		{
			OldEntryList = new List<InputEntry>(EntryList);
			
			Children.Clear();
			EntryList.Clear();
            ButtonList.Clear();

			for (int i = 0, lineId = 0; i <= currentMatrixDimension; i++)
			{
				for (int j = 0; j <= currentMatrixDimension; j++)
				{
					if ((i == currentMatrixDimension)
						|| (j == currentMatrixDimension))
                    {
                        lineId = CreateButton(i, j, lineId);
                    }
                    else
                    {
                        CreateEntry(i, j);
                    }
                }

			}

			AssignLines();

			UpdateResultsDelegate.UpdateResults();
		}

        private void CreateEntry(int i, int j)
        {
            InputEntry inputEntry = new InputEntry(i, j);
            inputEntry = CheckOldValueExist(inputEntry);

            Children.Add(inputEntry, j, i);
            EntryList.Add(inputEntry);
        }

        private int CreateButton(int i, int j, int lineId)
        {
            if (i != j)
            {
                GetInfoButton getInfoButton = new GetInfoButton(i, j, lineId);

                Children.Add(getInfoButton, j, i);
                ButtonList.Add(getInfoButton);
                lineId++;
            }
            else
            {
                UpdateButton updateButton = new UpdateButton();
                Children.Add(updateButton, j, i);
            }

            return lineId;
        }

        private InputEntry CheckOldValueExist(InputEntry inputEntry)
        {
            foreach (var oldEntry in OldEntryList)
            {
                if (oldEntry.Row == inputEntry.Row
                    && oldEntry.Column == inputEntry.Column)
                {
                    inputEntry = new InputEntry(oldEntry);
                    break;
                }
            }

            return inputEntry;
        }

        private void UpdateChildHeightWidth(object sender, EventArgs e)
		{
			ChildHeight = Children[0].Height;
			ChildWidth = Children[0].Width;

			FontManager.UpdateFontDelegate();
		}

		private void AssignLines()
		{
			Lines.Clear();

			foreach (var button in ButtonList)
			{
				List<InputEntry> line = new List<InputEntry>();
				foreach (var entry in EntryList)
				{
					if ((entry.Row == button.Row)
						|| (entry.Column == button.Column))
					{
						line.Add(entry);
					}

				}
				Lines.Add(line);
			}

		}
	}
}

