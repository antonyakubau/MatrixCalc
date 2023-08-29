using System;
namespace MatrixCalc.Model.MatrixInterfaces
{
	public interface IMatrixEntry : IMatrixCell
	{
        string Text { get; set; }
	}
}

