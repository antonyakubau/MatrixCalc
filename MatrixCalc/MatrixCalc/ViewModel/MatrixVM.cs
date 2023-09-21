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

		public int Min { get; set; }
		public int Max { get; set; }
		public int Average { get; set; }

		public MatrixVM(Matrix _MainMatrix)
		{
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
				Min = internalMath.RefreshMin(MainMatrix.EntryList);
				Max = internalMath.RefreshMax(MainMatrix.EntryList);
				Average = internalMath.RefreshAverage(MainMatrix.EntryList);
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
					internalMath.RefreshSum(lineId, MainMatrix.Lines),
					internalMath.RefreshMin(lineId, MainMatrix.Lines),
					internalMath.RefreshMax(lineId, MainMatrix.Lines),
					internalMath.RefreshAverage(lineId, MainMatrix.Lines));

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


