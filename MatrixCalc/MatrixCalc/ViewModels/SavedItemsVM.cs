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
        protected DB_Matrix _dbMatrix;

        public IEnumerable<IMatrixInfo> Matrices { get; set; }
		public SavedItemsVM(IMatrix mainMatrix)
		{
			_dbMatrix = mainMatrix as DB_Matrix;
			Matrices = new List<DB_Matrix>()
			{
				new DB_Matrix()
				{
					Id = 2,
					Name = "Second",
					Data = "0 1 2 3",
					Dimension = 2,
					Date = "05.11.2023"
				},
				new DB_Matrix()
				{
					Id = 3,
					Name = "Third",
					Data = "4 314 856 7 235 23 64 12 43",
					Dimension = 3,
					Date = "05.11.2023"
				}
			};
		}

		public ICommand OpenSavedMatrixCommand => new Command<int>((id) =>
		{
			try
			{
				IMatrixInfo matrixInfo = FindId(id);
				_dbMatrix.Load(matrixInfo);
            }
			catch (Exception ex)
			{
				ExceptionManager.ShowExceptionMessege(ex);
			}
		});

        private IMatrixInfo FindId(int id)
        {
			foreach (var matrix in Matrices)
			{
				if (matrix.Id == id)
				{
					return matrix;
				}
            }
            throw new NullReferenceException("Matrix not found");
        }
    }
}

