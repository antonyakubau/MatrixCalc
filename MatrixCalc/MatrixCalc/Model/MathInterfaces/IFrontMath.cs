using System;
using System.Collections.Generic;

namespace MatrixCalc.Model
{
	public interface IFrontMath
    {
        int RefreshMax(List<InputEntry> EntryList);
        int RefreshMin(List<InputEntry> EntryList);
        int RefreshAverage(List<InputEntry> EntryList);
    }
}

