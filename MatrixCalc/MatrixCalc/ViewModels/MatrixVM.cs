using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MatrixCalc.Models;
using MatrixCalc.Views;
using PropertyChanged;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace MatrixCalc.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	public class MatrixVM
	{
		private IMatrix _mainMatrix;

		public IPageMath InternalMath { get; set; }
		public int MinValue { get; private set; }
		public int MaxValue { get; private set; }
		public int AverageValue { get; private set; }

		public MatrixVM(IMatrix mainMatrix)
		{
			_mainMatrix = mainMatrix;
			InternalMath = new InternalMath();

            UpdateManager.UpdateResults += ExecuteUpdateResults;

			_mainMatrix.UpdateMatrix(_mainMatrix.Dimension.CurrentDimension);
		}

		public ICommand IncreaseDimensionCommand => new Command(
			execute: () =>
			{
				_mainMatrix.Dimension.IncreaseDimension();

				_mainMatrix.UpdateMatrix(_mainMatrix.Dimension.CurrentDimension);
				
			});

		public ICommand DecreaseDimensionCommand => new Command(() =>
		{
			_mainMatrix.Dimension.DecreaseDimension();

			_mainMatrix.UpdateMatrix(_mainMatrix.Dimension.CurrentDimension);
		});

		private void ExecuteUpdateResults()
		{
			UpdateResults.Execute(null);
		}

		public ICommand UpdateResults => new Command(() =>
		{
			try
			{
				MinValue = InternalMath.CalculateMin(_mainMatrix.EntryList);
				MaxValue = InternalMath.CalculateMax(_mainMatrix.EntryList);
				AverageValue = InternalMath.CalculateAverage(_mainMatrix.EntryList);
			}
			catch (Exception ex)
			{
				ExceptionManager.ShowExceptionMessege(ex);
				_mainMatrix.UpdateMatrix(_mainMatrix.Dimension.CurrentDimension);
			}
		});


		public ICommand GetInfo => new Command<int>((LineId) =>
		{
			try
			{
                ShowDialogManager.ShowMatrixMessege(
					InternalMath.CalculateSum(_mainMatrix.Lines[LineId]),
					InternalMath.CalculateMin(_mainMatrix.Lines[LineId]),
					InternalMath.CalculateMax(_mainMatrix.Lines[LineId]),
					InternalMath.CalculateAverage(_mainMatrix.Lines[LineId]));
			}
			catch (Exception ex)
			{
				ExceptionManager.ShowExceptionMessege(ex);
				_mainMatrix.UpdateMatrix(_mainMatrix.Dimension.CurrentDimension);
			}
		});

		public ICommand UpdateFromButton => new Command(() =>
		{
			_mainMatrix.UpdateValues();
			if (ShowDialogManager.ShowMatrixUpdated != null)
			{
                ShowDialogManager.ShowMatrixUpdated();
			}
		});
    }
}


