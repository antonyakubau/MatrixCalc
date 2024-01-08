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
        private DB_Matrix _dbMatrix;

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
					Size = 4,
					Date = "05.11.2023"
				},
				new DB_Matrix()
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
				IMatrixInfo matrixInfo = FindId(id);
                _dbMatrix.Id = matrixInfo.Id;
                _dbMatrix.Name = matrixInfo.Name;
                _dbMatrix.Data = matrixInfo.Data;
                _dbMatrix.Size = matrixInfo.Size;
                _dbMatrix.Date = matrixInfo.Date;
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

