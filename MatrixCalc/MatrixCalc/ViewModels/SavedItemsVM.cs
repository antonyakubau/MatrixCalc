using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using MatrixCalc.Models;
using MatrixCalc.Models.Interfaces;
using Xamarin.Forms;

namespace MatrixCalc.ViewModels
{
	public class SavedItemsVM
	{
		public IMatrix _mainMatrix;
		public IEnumerable<Matrix> Matrices { get; set; }
		public SavedItemsVM(IMatrix mainMatrix)
		{
			_mainMatrix = mainMatrix;
			Matrices = new List<Matrix>()
			{
				new Matrix()
				{
					Id = 2,
					Name = "Second",
					Data = "0 1 2 3",
					Size = 4,
					Date = "05.11.2023"
				},
				new Matrix()
				{
					Id = 3,
					Name = "Third",
					Data = "4 314 856 7 235 23 64 12 43",
					Size = 9,
					Date = "05.11.2023"
				}
			};
		}

		public ICommand OpenSavedMatrixCommand => new Command<int>((id) =>
		{
			try
			{
				IMatrixInfo newMatrix = new Matrix();
				_mainMatrix.Id = 1;
			}
			catch (Exception ex)
			{
				ExceptionManager.ShowExceptionMessege(ex);
			}
		}); 

	}
}

