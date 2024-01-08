using System;
using MatrixCalc.Models.Interfaces;
using SQLite;
using Xamarin.Forms;

namespace MatrixCalc.Models
{
	public class MatrixInfo : Grid, IMatrixInfo
    {
        [PrimaryKey, AutoIncrement]
        public new int Id { get; set; }
        public string Name { get; set; }
        public string Values { get; set; }
        public int Size { get; set; }
        public string Date { get; set; }

        public MatrixInfo()
		{
		}

    }
}

