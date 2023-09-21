using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MatrixCalc.Model
{
	public class Matrix : Grid
	{
		public static double ChildHeight { get; set; }
		public static double ChildWidth { get; set; }

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
			List<InputEntry> oldEntryList = new List<InputEntry>(EntryList);
            int lineId = 0;

            Children.Clear();
			EntryList.Clear();
			ButtonList.Clear();

			for (int i = 0; i < currentMatrixDimension; i++)
			{
				for (int j = 0; j < currentMatrixDimension; j++)
				{
					if ((i == currentMatrixDimension - 1)
						|| (j == currentMatrixDimension - 1))
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
					}
					else
					{
						InputEntry inputEntry = new InputEntry(i, j);

                        foreach (var oldEntry in oldEntryList)
						{
							if (oldEntry.Row == i
								&& oldEntry.Column == j)
							{
								inputEntry = new InputEntry(oldEntry);
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

