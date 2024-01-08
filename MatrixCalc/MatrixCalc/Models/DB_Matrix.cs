using System;
using MatrixCalc.Models.Interfaces;

namespace MatrixCalc.Models
{
	public class DB_Matrix : Matrix, IMatrixInfo
    {

        public new int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public int Size { get; set; }
        public string Date { get; set; }

        public DB_Matrix()
		{
            
		}

        public override void UpdateMatrix(int currentMatrixDimension)
        {

        }
    }
}

