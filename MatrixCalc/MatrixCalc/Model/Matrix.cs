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
            ClearOldChildrens();
            GetInfoButton.LastLineId = 0;

            CreateChildrens(currentMatrixDimension);

            AssignLines();

            UpdateResultsDelegate.UpdateResults();
        }

        private void ClearOldChildrens()
        {
            Children.Clear();
            EntryList.Clear();
            ButtonList.Clear();
        }

        private void CreateChildrens(int currentMatrixDimension)
        {
            for (int i = 0; i <= currentMatrixDimension; i++)
            {
                for (int j = 0; j <= currentMatrixDimension; j++)
                {
                    if ((i == currentMatrixDimension)
                        || (j == currentMatrixDimension))
                    {
                        CreateButton(i, j);
                    }
                    else
                    {
                        CreateEntry(i, j);
                    }
                }

            }
        }

        private void CreateEntry(int i, int j)
        {
            InputEntry inputEntry = new InputEntry(i, j);
            inputEntry = CheckOldValueExist(inputEntry);

            Children.Add(inputEntry, j, i);
            EntryList.Add(inputEntry);
        }

        private void CreateButton(int i, int j)
        {
            if (i != j)
            {
                GetInfoButton getInfoButton = new GetInfoButton(i, j);

                Children.Add(getInfoButton, j, i);
                ButtonList.Add(getInfoButton);
				GetInfoButton.LastLineId++;
            }
            else
            {
                UpdateButton updateButton = new UpdateButton();
                Children.Add(updateButton, j, i);
            }
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
                List<InputEntry> Line = new List<InputEntry>();
                FillLine(Line, button);
                Lines.Add(Line);
            }

        }

        private void FillLine(List<InputEntry> Line, GetInfoButton button)
        {
            foreach (var entry in EntryList)
            {
                if ((entry.Row == button.Row)
                    || (entry.Column == button.Column))
                {
                    Line.Add(entry);
                }
            }
        }
    }
}

