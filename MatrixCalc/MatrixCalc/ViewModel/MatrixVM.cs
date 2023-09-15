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
        private Matrix MainMatrix;
        private int currentMatrixDimension;
        private IPageMath internalMath;
        private readonly Dimension dimension;

        public List<InputEntry> EntryList { get; set; }
        public List<GetInfoButton> ButtonList { get; set; }

        public int Min { get; set; }
        public int Max { get; set; }
        public int Average { get; set; }

        public delegate void UpdateHandler();
        public static UpdateHandler UpdateMatrixAndNotify;

        public MatrixVM(MatrixPage _matrixPage, Matrix _MainMatrix)
        {
            EntryList = new List<InputEntry>();
            ButtonList = new List<GetInfoButton>();

            matrixPage = _matrixPage;
            MainMatrix = _MainMatrix;
            MainMatrix.EntryList = EntryList;
            MainMatrix.ButtonList = ButtonList;

            dimension = new Dimension()
            {
                LowerBound = 3,
                UpperBound = 7,
                StartDimension = 5
            };
            currentMatrixDimension = dimension.StartDimension;

            internalMath = new InternalMath()
            {
                EntryList = this.EntryList,
                ButtonList = this.ButtonList,
                Lines = MainMatrix.Lines
            };

            UpdateResultsDelegate.UpdateResults = ExecuteUpdateResults;

            UpdateMatrixAndNotify += UpdateMainMatrix;
            UpdateMainMatrix();
        }




        public void UpdateMainMatrix()
        {
            MainMatrix.Children.Clear();
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
                            MainMatrix.Children.Add(getInfoButton, j, i);

                            ButtonList.Add(getInfoButton);
                            buttonId++;
                        }
                        else
                        {
                            UpdateButton updateButton = new UpdateButton();
                            MainMatrix.Children.Add(updateButton, j, i);
                        }
                    }
                    else
                    {
                        InputEntry inputEntry = new InputEntry()
                        {
                            Row = i,
                            Column = j
                        };
                        MainMatrix.Children.Add(inputEntry, j, i);
                        EntryList.Add(inputEntry);
                    }
                }

            }

            UpdateResults.Execute(null);
        }


        public Command IncreaseDimensionCommand => new Command(() =>
        {
            int newDimension = dimension.IncreaseDimension
            (currentMatrixDimension);

            if (newDimension != currentMatrixDimension)
            {
                currentMatrixDimension = newDimension;
                UpdateMainMatrix();
            }
        });

        public Command DecreaseDimensionCommand => new Command(() =>
        {
            int newDimension = dimension.DecreaseDimension
            (currentMatrixDimension);

            if (newDimension != currentMatrixDimension)
            {
                currentMatrixDimension = newDimension;
                UpdateMainMatrix();
            }
        });

        private void ExecuteUpdateResults()
        {
            UpdateResults.Execute(null);
        }

        public Command UpdateResults => new Command(() =>
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
                MainMatrix.AssignLines();
                matrixPage.ShowMessage(
                    internalMath.RefreshSum(lineId),
                    internalMath.RefreshMin(lineId),
                    internalMath.RefreshMax(lineId),
                    internalMath.RefreshAverage(lineId));

                UpdateResults.Execute(null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.ExceptionMessege(ex);
                UpdateMainMatrix();
            }
        });

        public Command UpdateFromButton => new Command(() =>
        {
            UpdateMatrixAndNotify();
        });
    }
}


