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

            internalMath = new InternalMath(MainMatrix);

            UpdateResultsDelegate.UpdateResults = ExecuteUpdateResults;

            MainMatrix.UpdateMainMatrix(currentMatrixDimension);
        }



        public Command IncreaseDimensionCommand => new Command(() =>
        {
            int newDimension = dimension.IncreaseDimension
            (currentMatrixDimension);

            if (newDimension != currentMatrixDimension)
            {
                currentMatrixDimension = newDimension;
                MainMatrix.UpdateMainMatrix(currentMatrixDimension);
            }
        });

        public Command DecreaseDimensionCommand => new Command(() =>
        {
            int newDimension = dimension.DecreaseDimension
            (currentMatrixDimension);

            if (newDimension != currentMatrixDimension)
            {
                currentMatrixDimension = newDimension;
                MainMatrix.UpdateMainMatrix(currentMatrixDimension);
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

                UpdateResultsDelegate.UpdateResults();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ExceptionMessege(ex);
                MainMatrix.UpdateMainMatrix(currentMatrixDimension);
            }
        });

        public Command UpdateFromButton => new Command(() =>
        {
            Matrix.UpdateMatrixAndNotify(currentMatrixDimension);
        });
    }
}


