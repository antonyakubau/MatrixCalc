using System;
using System.Collections;
using System.Collections.Generic;
using MatrixCalc.Models;

namespace MatrixCalc.ViewModels
{
	public class SavedItemsVM
	{
		public IEnumerable<Matrix> Matrices { get; set; }
		public SavedItemsVM()
		{
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
	}
}

