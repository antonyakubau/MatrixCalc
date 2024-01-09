using System;
using System.Collections.Generic;

namespace MatrixCalc.Models.Interfaces
{
	public interface IMatrixInfo
	{
        int Id { get; }
        string Name { get; }
        string Values { get; }
        int Size { get; }
        string Date { get; }
    }
}

