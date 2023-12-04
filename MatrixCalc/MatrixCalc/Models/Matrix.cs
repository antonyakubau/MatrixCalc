using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace MatrixCalc.Model
{
    public class Matrix : Grid, IMatrix
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

            ColumnSpacing = 1;
            RowSpacing = 1;
            Margin = 0;
            Padding = 0;
            BackgroundColor = Color.AliceBlue;

            SizeChanged += UpdateChildHeightWidth;
            LayoutChanged += UpdateChildHeightWidth;
        }

        public void UpdateValues()
        {
            foreach (var entry in EntryList)
            {
                entry.Text = entry.GenerateNewValue().InRange(1, 999);
            }
        }

        public void UpdateMatrix(int currentMatrixDimension)
        {
            OldEntryList = new List<InputEntry>(EntryList);

            ClearOldChildren();
            CreateChildren(currentMatrixDimension);
            AssignLines();
            if (UpdateManager.UpdateResults != null)
            {
                UpdateManager.UpdateResults();
            }
        }

        private void ClearOldChildren()
        {
            Children.Clear();
            EntryList.Clear();
            ButtonList.Clear();
            GetInfoButton.LastLineId = 0;
        }

        private void CreateChildren(int currentMatrixDimension)
        {
            for (int row = 0; row <= currentMatrixDimension; row++)
            {
                for (int column = 0; column <= currentMatrixDimension; column++)
                {
                    if ((row == currentMatrixDimension)
                        || (column == currentMatrixDimension))
                    {
                        CreateButton(row, column);
                    }
                    else
                    {
                        CreateEntry(row, column);
                    }
                }

            }
        }

        private void CreateButton(int row, int column)
        {
            if (row != column)
            {
                GetInfoButton getInfoButton = new GetInfoButton(row, column);
                MatrixFrame buttonFrame = new MatrixFrame(getInfoButton);
                AddToChildren(buttonFrame, row, column);
                GetInfoButton.LastLineId++;
            }
            else
            {
                UpdateButton updateButton = new UpdateButton();
                MatrixFrame buttonFrame = new MatrixFrame(updateButton);
                AddToChildren(buttonFrame, row, column);
            }
        }

        private void CreateEntry(int row, int column)
        {
            InputEntry inputEntry = new InputEntry(row, column);
            inputEntry = CheckOldValueExists(inputEntry);
            MatrixFrame entryFrame = new MatrixFrame(inputEntry);
            AddToChildren(entryFrame, row, column);
        }

        private InputEntry CheckOldValueExists(InputEntry inputEntry)
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

        private void AddToChildren(MatrixFrame frame, int row, int column)
        {
            Children.Add(frame, column, row);
            if (frame.Content is InputEntry inputEntry)
                EntryList.Add(inputEntry);
            else
            if (frame.Content is GetInfoButton getInfoButton)
                ButtonList.Add(getInfoButton);

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

        private void UpdateChildHeightWidth(object sender, EventArgs e)
        {
            ChildHeight = Children[0].Height;
            ChildWidth = Children[0].Width;

            if (UpdateManager.UpdateFont != null)
            {
                UpdateManager.UpdateFont(Children[0].Height, Children[0].Width);
            }
        }
    }
}