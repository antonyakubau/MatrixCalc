using System;
using System.Collections.Generic;
using MatrixCalc.ViewModel;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class Matrix : Grid
	{
        public static double ChildHeight { get; set; }
        public static double ChildWidth { get; set; }

        public List<InputEntry> EntryList { get; set; }
        public List<GetInfoButton> ButtonList { get; set; }
        public List<List<int>> Lines { get; set; }

        public delegate void UpdateHandler(int currentMatrixDimension);
        public static UpdateHandler UpdateMatrixAndNotify;

        public Matrix()
        {
            EntryList = new List<InputEntry>();
            ButtonList = new List<GetInfoButton>();
            Lines = new List<List<int>>();

            SizeChanged += UpdateChildHeightWidth;
            LayoutChanged += UpdateChildHeightWidth;

            UpdateMatrixAndNotify += UpdateMainMatrix;
        }

        public void UpdateMainMatrix(int currentMatrixDimension)
        {
            Children.Clear();
            EntryList.Clear();
            ButtonList.Clear();

            int buttonId = 0;

            for (int i = 0; i < currentMatrixDimension; i++)
            {
                for (int j = 0; j < currentMatrixDimension; j++)
                {
                    if ((i == currentMatrixDimension - 1)
                        || (j == currentMatrixDimension - 1))
                    {
                        if (i != j)
                        {
                            GetInfoButton getInfoButton = new GetInfoButton()
                            {
                                Row = i,
                                Column = j,
                                LineId = buttonId,
                                CommandParameter = Convert.ToString(buttonId)
                            };
                            Children.Add(getInfoButton, j, i);

                            ButtonList.Add(getInfoButton);
                            buttonId++;
                        }
                        else
                        {
                            UpdateButton updateButton = new UpdateButton();
                            Children.Add(updateButton, j, i);
                        }
                    }
                    else
                    {
                        InputEntry inputEntry = new InputEntry()
                        {
                            Row = i,
                            Column = j
                        };
                        Children.Add(inputEntry, j, i);
                        EntryList.Add(inputEntry);
                    }
                }

            }

            UpdateResultsDelegate.UpdateResults();
        }


        private void UpdateChildHeightWidth(object sender, EventArgs e)
        {
            ChildHeight = Children[0].Height;
            ChildWidth = Children[0].Width;

            FontManager.UpdateFontDelegate();
        }

        public void AssignLines()
        {
            Lines.Clear();

            foreach (var button in ButtonList)
            {
                List<int> line = new List<int>();
                foreach (var entry in EntryList)
                {
                    if ((entry.Row == button.Row)
                        || (entry.Column == button.Column))
                    {
                        line.Add(Convert.ToInt32(entry.Text));
                    }

                }
                Lines.Add(line);
            }

        }
    }
}

