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
		private IMatrix _mainMatrix;
		private int _currentMatrixDimension;
		private IPageMath _internalMath;
		private readonly Dimension _dimension;

		public int LowerBound { get; private set; }
        public int UpperBound { get; private set; }
        public int StartDimension { get; private set; }
        public int MinValueOfMatrix { get; private set; }
		public int MaxValueOfMatrix { get; private set; }
		public int AverageValueOfMatrix { get; private set; }

		public MatrixVM(IMatrix mainMatrix)
		{
			_mainMatrix = mainMatrix;

			LowerBound = 2;
			UpperBound = 7;
			StartDimension = 4;

			_dimension = new Dimension(LowerBound, UpperBound, StartDimension);
			_currentMatrixDimension = _dimension.StartDimension;

			_internalMath = new InternalMath();

			UpdateResultsDelegate.UpdateResults = ExecuteUpdateResults;

			_mainMatrix.UpdateMatrix(_currentMatrixDimension);
		}

        public ICommand IncreaseDimensionCommand => new Command(
			execute:() =>
			{
				int newDimension = _dimension.IncreaseDimension
				(_currentMatrixDimension);

				if (newDimension != _currentMatrixDimension)
				{
					_currentMatrixDimension = newDimension;
					_mainMatrix.UpdateMatrix(_currentMatrixDimension);
                }
            });

		public ICommand DecreaseDimensionCommand => new Command(() =>
		{
			int newDimension = _dimension.DecreaseDimension
			(_currentMatrixDimension);

			if (newDimension != _currentMatrixDimension)
			{
				_currentMatrixDimension = newDimension;
				_mainMatrix.UpdateMatrix(_currentMatrixDimension);
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
				MinValueOfMatrix = _internalMath.CalculateMin(_mainMatrix.EntryList);
				MaxValueOfMatrix = _internalMath.CalculateMax(_mainMatrix.EntryList);
				AverageValueOfMatrix = _internalMath.CalculateAverage(_mainMatrix.EntryList);
			}
			catch (Exception ex)
			{
				ExceptionManager.ShowExceptionMessege(ex);
				_mainMatrix.UpdateMatrix(_currentMatrixDimension);
			}
		});


		public ICommand GetInfo => new Command<int>((int LineId) =>
		{
			try
			{
				MatrixPage.ShowMatrixMessege(
					_internalMath.CalculateSum(_mainMatrix.Lines[LineId]),
					_internalMath.CalculateMin(_mainMatrix.Lines[LineId]),
					_internalMath.CalculateMax(_mainMatrix.Lines[LineId]),
					_internalMath.CalculateAverage(_mainMatrix.Lines[LineId]));
			}
			catch (Exception ex)
			{
				ExceptionManager.ShowExceptionMessege(ex);
				_mainMatrix.UpdateMatrix(_currentMatrixDimension);
			}
		});

		public ICommand UpdateFromButton => new Command(() =>
		{
			_mainMatrix.UpdateValues();
			if (MatrixPage.ShowMatrixUpdated != null)
			{
                MatrixPage.ShowMatrixUpdated();
            }
		});
	}
}


