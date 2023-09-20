using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class Matrix : Grid
	{
        public static double ChildHeight { get; set; }
        public static double ChildWidth { get; set; }

        public List<InputEntry> EntryList { get; }
        public List<GetInfoButton> ButtonList { get; }
        public List<List<InputEntry>> Lines { get; }

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
            List<InputEntry> oldEntryList = new List<InputEntry>(EntryList);

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

                        foreach (var oldEntry in oldEntryList)
                        {
                            if (oldEntry.Row == inputEntry.Row
                                && oldEntry.Column == inputEntry.Column)
                            {
                                inputEntry.TextChanged -= inputEntry.UpdateResults;
                                inputEntry.Text = oldEntry.Text;
                                inputEntry.TextChanged += inputEntry.UpdateResults;
                                break;
                            }
                        }

                        Children.Add(inputEntry, j, i);
                        EntryList.Add(inputEntry);
                    }
                }

            }

            AssignLines();

            UpdateResultsDelegate.UpdateResults();
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

