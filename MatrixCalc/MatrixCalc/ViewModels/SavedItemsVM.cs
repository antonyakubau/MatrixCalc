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
			Matrices = new List<dbt>()
			{
				new dbt()
				{
					Id = 2,
					Name = "Second",
					//Values = new List<string>(){"0", "1", "2", "3" }.ToString(),
					Values = "0;1;2;3",
					Size = 2,
					Date = "05.11.2023"
				},
				new dbt()
				{
					Id = 3,
					Name = "Third",
					//Values = new List<string>(){"4", "314", "856", "7", "235", "23", "64", "12", "43" }.ToString(),
					Values = "4;314;856;7;235;23;64;12;43",
					Size = 3,
					Date = "05.11.2023"
				}
			};
			App.Database.SaveDB_MatrixAsync(new dbt()
			{
				Id = 3,
				Name = "Third",
				//Values = new List<string>(){"4", "314", "856", "7", "235", "23", "64", "12", "43" }.ToString(),
				Values = "4;314;856;7;235;23;64;12;43",
				Size = 3,
				Date = "05.11.2023"

			});
		}

		//public ICommand OpenSavedMatrixCommand => new Command<DB_Matrix>((matrix) =>

        public ICommand OpenSavedMatrixCommand => new Command<int>((id) =>
        {
			try
			{
				_dbMatrix.Load(FindId(id));

            }
			catch (Exception ex)
			{
				ExceptionManager.ShowExceptionMessege(ex);
			}
		});

        //private async void GetMatrices()
        //{
        //    await App.Database.SavePersonAsync(new Person
        //    {
        //        Name = nameEntry.Text,
        //        Age = int.Parse(ageEntry.Text)
        //    });

        //    nameEntry.Text = ageEntry.Text = string.Empty;
        //    collectionView.ItemsSource = await App.Database.GetPeopleAsync();
        
        //}
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

