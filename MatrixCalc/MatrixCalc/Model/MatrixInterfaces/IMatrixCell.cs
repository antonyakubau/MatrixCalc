using System;
namespace MatrixCalc.Model.MatrixInterfaces
{
	public interface IMatrixCell
	{
        int Row { get; set; }
        int Column { get; set; }
        int LineId { get; set; }
    }
}

