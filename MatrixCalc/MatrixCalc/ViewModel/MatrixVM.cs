using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MatrixCalc.Model;
using PropertyChanged;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace MatrixCalc.ViewModel
{
    [AddINotifyPropertyChangedInterface]
	public class MatrixVM
	{
        private MatrixPage matrixPage;
        private Grid MainMatrix;
        private int currentMatrixDimension;
        private IPageMath internalMath;
        private readonly Dimension dimension;

        private List<InputEntry> EntryList = new List<InputEntry>();
        private List<GetInfoButton> ButtonList = new List<GetInfoButton>();
        private List<List<int>> Lines = new List<List<int>>();

        public int Min { get; set; }
        public int Max { get; set; }
        public int Average { get; set; }

        public MatrixVM(MatrixPage _matrixPage, Grid _MainMatrix)
        {
            matrixPage = _matrixPage;
            MainMatrix = _MainMatrix;
            dimension = new Dimension()
            {
                StartDimension = 6,
                LowerBound = 3,
                UpperBound = 8
            };

            currentMatrixDimension = dimension.StartDimension;

            internalMath = new InternalMath()
            {
                EntryList = this.EntryList,
                ButtonList = this.ButtonList,
                Lines = this.Lines
            };


            UpdateMainMatrix();
        }




        public void UpdateMainMatrix()
        {
            MainMatrix.Children.Clear();
            EntryList.Clear();
            ButtonList.Clear();

            int buttonId = 0;
            Random random = new Random();

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
                            MainMatrix.Children.Add(getInfoButton, j, i);

                            ButtonList.Add(getInfoButton);
                            buttonId++;
                        }
                    }
                    else
                    {
                        InputEntry inputEntry = new InputEntry()
                        { 
                            Text = random.Next(1, 999).ToString(),
                            Row = i,
                            Column = j
                        };
                        MainMatrix.Children.Add(inputEntry, j, i);
                        EntryList.Add(inputEntry);
                    }
                }

            }
            RefreshResults.Execute(null);
        }

        private void AssignLines()
        {
            Lines.Clear();

            foreach (var button in ButtonList)
            {
                List<int> line = new List<int>();
                foreach (var entry in EntryList)
                {
                    if ((entry.Row == button.Row )
                        || (entry.Column == button.Column ))
                    {
                        line.Add(Convert.ToInt32(entry.Text));
                    }
                    
                }
                Lines.Add(line);
            }

        }


        public Command ChangeDimensionCommand => new Command((action) =>
        {
            int newDimension = dimension.ChangeDimension
            ((string)action, currentMatrixDimension);

            if (newDimension != currentMatrixDimension)
            {
                currentMatrixDimension = newDimension;
                UpdateMainMatrix();
            }
        });


        public Command RefreshResults => new Command(() =>
        {
            Min = internalMath.RefreshMin();
            Max = internalMath.RefreshMax();
            Average = internalMath.RefreshAverage();
        });



        public Command GetInfo => new Command((LineId) =>
        {
            try
            {
                int lineId = Convert.ToInt32(LineId);
                AssignLines();
                matrixPage.ShowMessage(
                    internalMath.RefreshSum(lineId),
                    internalMath.RefreshMin(lineId),
                    internalMath.RefreshMax(lineId),
                    internalMath.RefreshAverage(lineId));

                RefreshResults.Execute(null);
            }
            catch (Exception ex)
            {
                UpdateMainMatrix();
            }
        });

    }
}


