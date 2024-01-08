using System;
namespace MatrixCalc.Models.Interfaces
{
	public interface IMatrixInfo
	{
        int Id { get; set; }
        string Name { get; set; }
        string Data { get; set; }
        int Dimension { get; set; }
        string Date { get; set; }
    }
}

