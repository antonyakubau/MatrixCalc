using System;
using MatrixCalc.Models.Interfaces;
using PropertyChanged;
using SQLite;
using Xamarin.Forms;

namespace MatrixCalc.Models
{
    [AddINotifyPropertyChangedInterface]
	public class MatrixInfo : IMatrixInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Values { get; set; }
        public int Size { get; set; }
        public string Date { get; set; }

        public MatrixInfo()
		{
		}

        public MatrixInfo(IMatrixInfo matrix)
        {
            Name = matrix.Name;
            Values = matrix.Values;
            Size = matrix.Size;
            Date = matrix.Date;
        }
    }
}

