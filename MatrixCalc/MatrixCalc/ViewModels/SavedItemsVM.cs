using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using MatrixCalc.Models;
using MatrixCalc.Models.Interfaces;
using PropertyChanged;
using Xamarin.Forms;

namespace MatrixCalc.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SavedItemsVM
	{
        protected DB_Matrix _dbMatrix;

        public List<MatrixInfo> DbMatrices { get; private set; }
        public IEnumerable<IMatrixInfo> Matrices { get; set; }

		public SavedItemsVM(IMatrix mainMatrix)
		{
			_dbMatrix = mainMatrix as DB_Matrix;
            Matrices = new List<MatrixInfo>()
			{
				new MatrixInfo()
				{
					Id = 2,
					Name = "Second",
					//Values = new List<string>(){"0", "1", "2", "3" }.ToString(),
					Values = "0;1;2;3",
					Size = 2,
					Date = "05.11.2023"
				},
				new MatrixInfo()
				{
					Id = 3,
					Name = "Third",
					//Values = new List<string>(){"4", "314", "856", "7", "235", "23", "64", "12", "43" }.ToString(),
					Values = "4;314;856;7;235;23;64;12;43",
					Size = 3,
					Date = "05.11.2023"
				}
			};
			App.Database.SaveDbMatrixAsync(new DB_Matrix()
			{
				Name = "Third",
				//Values = new List<string>(){"4", "314", "856", "7", "235", "23", "64", "12", "43" }.ToString(),
				Values = "4;314;856;7;235;23;64;12;43",
				Size = 3,
				Date = "05.11.2023"

			});
            GetMatrices();
        }

		//public ICommand OpenSavedMatrixCommand => new Command<DB_Matrix>((matrix) =>

        public ICommand OpenSavedMatrixCommand => new Command<int>((id) =>
        {
			try
			{
				GetMatrices();
				_dbMatrix.Load(FindMatrix(id));

            }
			catch (Exception ex)
			{
				ExceptionManager.ShowExceptionMessege(ex);
			}
		});

        public async void GetMatrices()
		{
			DbMatrices = await App.Database.GetDbMatricesAsync();
		}

		private MatrixInfo FindMatrix(int id)
        {
			foreach (var matrix in DbMatrices)
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

