using System.Collections.Generic;
using MatrixCalc.Models.Interfaces;

namespace MatrixCalc.Models
{
    public interface IMatrix : IMatrixInfo
    {
        List<InputEntry> OldEntryList { get; }
        List<InputEntry> EntryList { get; }
        List<GetInfoButton> ButtonList { get; }
        List<List<InputEntry>> Lines { get; }

        void UpdateMatrix(int currentMatrixDimension);
        void UpdateValues();
    }
}