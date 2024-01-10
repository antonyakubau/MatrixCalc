using System;
using MatrixCalc.Models.Interfaces;
using PropertyChanged;
using SQLite;
using Xamarin.Forms;

namespace MatrixCalc.Models
{
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

        public MatrixInfo(IMatrixInfo copiedMatrix)
        {
            Name = copiedMatrix.Name;
            Values = copiedMatrix.Values;
            Size = copiedMatrix.Size;
            Date = copiedMatrix.Date;
        }
    }
}

