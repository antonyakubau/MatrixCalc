using System;
using System.Collections.Generic;

namespace MatrixCalc.Models.Interfaces
{
	public interface IMatrixInfo
	{
        int Id { get; set; }
        string Name { get; set; }
        List<string> Values { get; set; }
        int Size { get; set; }
        string Date { get; set; }
    }
}

