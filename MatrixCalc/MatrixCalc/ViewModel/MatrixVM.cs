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
		private Matrix _mainMatrix;
		private int _currentMatrixDimension;
		private IPageMath _internalMath;
		private readonly Dimension _dimension;

		public int LowerBound { get; private set; }
        public int UpperBound { get; private set; }
        public int StartDimension { get; private set; }
        public int Min { get; private set; }
		public int Max { get; private set; }
		public int Average { get; private set; }

		public MatrixVM(Matrix mainMatrix)
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



		public ICommand IncreaseDimensionCommand => new Command(() =>
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
				Min = _internalMath.CalculateMin(_mainMatrix.EntryList);
				Max = _internalMath.CalculateMax(_mainMatrix.EntryList);
				Average = _internalMath.CalculateAverage(_mainMatrix.EntryList);
			}
			catch (Exception ex)
			{
				ExceptionManager.ExceptionMessege(ex);
				_mainMatrix.UpdateMatrix(_currentMatrixDimension);
			}
		});


		public ICommand GetInfo => new Command((LineId) =>
		{
			try
			{
				int lineId = Convert.ToInt32(LineId);
				MatrixPage.ShowMatrixMessege(
					_internalMath.CalculateSum(_mainMatrix.Lines[lineId]),
					_internalMath.CalculateMin(_mainMatrix.Lines[lineId]),
					_internalMath.CalculateMax(_mainMatrix.Lines[lineId]),
					_internalMath.CalculateAverage(_mainMatrix.Lines[lineId]));
			}
			catch (Exception ex)
			{
				ExceptionManager.ExceptionMessege(ex);
				_mainMatrix.UpdateMatrix(_currentMatrixDimension);
			}
		});

		public ICommand UpdateFromButton => new Command(() =>
		{
			_mainMatrix.UpdateValues();
			MatrixPage.ShowMatrixUpdated();
		});
	}
}


