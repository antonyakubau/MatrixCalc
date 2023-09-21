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
		private Matrix MainMatrix;
		private int currentMatrixDimension;
		private IPageMath internalMath;
		private readonly Dimension dimension;

		public int LowerBound { get; private set; }
        public int UpperBound { get; private set; }
        public int StartDimension { get; private set; }
        public int Min { get; private set; }
		public int Max { get; private set; }
		public int Average { get; private set; }

		public MatrixVM(Matrix _MainMatrix)
		{
			MainMatrix = _MainMatrix;

			LowerBound = 2;
			UpperBound = 7;
			StartDimension = 4;

			dimension = new Dimension(LowerBound, UpperBound, StartDimension);
			currentMatrixDimension = dimension.StartDimension;

			internalMath = new InternalMath();

			UpdateResultsDelegate.UpdateResults = ExecuteUpdateResults;

			MainMatrix.UpdateMatrix(currentMatrixDimension);
		}



		public ICommand IncreaseDimensionCommand => new Command(() =>
		{
			int newDimension = dimension.IncreaseDimension
			(currentMatrixDimension);

			if (newDimension != currentMatrixDimension)
			{
				currentMatrixDimension = newDimension;
				MainMatrix.UpdateMatrix(currentMatrixDimension);
			}
		});

		public ICommand DecreaseDimensionCommand => new Command(() =>
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

		public ICommand UpdateResults => new Command(() =>
		{
			try
			{
				Min = internalMath.CalculateMin(MainMatrix.EntryList);
				Max = internalMath.CalculateMax(MainMatrix.EntryList);
				Average = internalMath.CalculateAverage(MainMatrix.EntryList);
			}
			catch (Exception ex)
			{
				ExceptionManager.ExceptionMessege(ex);
				MainMatrix.UpdateMatrix(currentMatrixDimension);
			}
		});


		public ICommand GetInfo => new Command((LineId) =>
		{
			try
			{
				int lineId = Convert.ToInt32(LineId);
				MatrixPage.ShowMatrixMessege(
					internalMath.CalculateSum(MainMatrix.Lines[lineId]),
					internalMath.CalculateMin(MainMatrix.Lines[lineId]),
					internalMath.CalculateMax(MainMatrix.Lines[lineId]),
					internalMath.CalculateAverage(MainMatrix.Lines[lineId]));

				UpdateResultsDelegate.UpdateResults();
			}
			catch (Exception ex)
			{
				ExceptionManager.ExceptionMessege(ex);
				MainMatrix.UpdateMatrix(currentMatrixDimension);
			}
		});

		public ICommand UpdateFromButton => new Command(() =>
		{
			MainMatrix.UpdateValues();
			MatrixPage.ShowMatrixUpdated();
		});
	}
}


