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

        public int Min { get; set; }
        public int Max { get; set; }
        public int Average { get; set; }

        public MatrixVM(MatrixPage _matrixPage, Matrix _MainMatrix)
        {
            matrixPage = _matrixPage;
            MainMatrix = _MainMatrix;

            dimension = new Dimension()
            {
                LowerBound = 3,
                UpperBound = 7,
                StartDimension = 5
            };
            currentMatrixDimension = dimension.StartDimension;

            internalMath = new InternalMath();

            UpdateResultsDelegate.UpdateResults = ExecuteUpdateResults;

            MainMatrix.UpdateMatrix(currentMatrixDimension);
        }



        public Command IncreaseDimensionCommand => new Command(() =>
        {
            int newDimension = dimension.IncreaseDimension
            (currentMatrixDimension);

            if (newDimension != currentMatrixDimension)
            {
                currentMatrixDimension = newDimension;
                MainMatrix.UpdateMatrix(currentMatrixDimension);
            }
        });

        public Command DecreaseDimensionCommand => new Command(() =>
        {
            int newDimension = dimension.DecreaseDimension
            (currentMatrixDimension);

            if (newDimension != currentMatrixDimension)
            {
                currentMatrixDimension = newDimension;
                MainMatrix.UpdateMatrix(currentMatrixDimension);
            }
        });

        private void ExecuteUpdateResults()
        {
            UpdateResults.Execute(null);
        }

        public Command UpdateResults => new Command(() =>
        {
            Min = internalMath.RefreshMin(MainMatrix.EntryList);
            Max = internalMath.RefreshMax(MainMatrix.EntryList);
            Average = internalMath.RefreshAverage(MainMatrix.EntryList);
        });


        public Command GetInfo => new Command((LineId) =>
        {
            try
            {
                int lineId = Convert.ToInt32(LineId);
                matrixPage.ShowMessage(
                    internalMath.RefreshSum(lineId, MainMatrix.Lines),
                    internalMath.RefreshMin(lineId, MainMatrix.Lines),
                    internalMath.RefreshMax(lineId, MainMatrix.Lines),
                    internalMath.RefreshAverage(lineId, MainMatrix.Lines));

                UpdateResultsDelegate.UpdateResults();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ExceptionMessege(ex);
                MainMatrix.UpdateMatrix(currentMatrixDimension);
            }
        });

        public Command UpdateFromButton => new Command(() =>
        {
            MainMatrix.UpdateMatrix(currentMatrixDimension);
            MatrixPage.ShowMatrixUpdated();
        });
    }
}


