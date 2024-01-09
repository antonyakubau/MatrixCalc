using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

            GetMatrices();
        }

        public ICommand OpenSavedMatrixCommand => new Command<int>((id) =>
        {
			try
			{
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

