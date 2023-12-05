using System.Collections.Generic;

namespace MatrixCalc.Models
{
    public interface IMatrix
    {
        List<InputEntry> OldEntryList { get; }
        List<InputEntry> EntryList { get; }
        List<GetInfoButton> ButtonList { get; }
        List<List<InputEntry>> Lines { get; }

        void UpdateMatrix(int currentMatrixDimension);
        void UpdateValues();
    }
}