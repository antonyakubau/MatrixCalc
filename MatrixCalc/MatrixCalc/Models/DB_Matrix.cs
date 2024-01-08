using System;
using System.Collections.Generic;
using MatrixCalc.Models.Interfaces;

namespace MatrixCalc.Models
{
    public class DB_Matrix : Matrix, IMatrixInfo
    {

        public new int Id { get; set; }
        public string Name { get; set; }
        public List<string> Values { get; set; }
        public int Size { get; set; }
        public string Date { get; set; }

        public DB_Matrix()
        {

        }


        public virtual void Load(IMatrixInfo matrixInfo)
        {
            LoadInfo(matrixInfo);

            UpdateMatrix();

            LoadValues();

            if (UpdateManager.UpdateResults != null)
            {
                UpdateManager.UpdateResults();
            }
        }

        private void LoadValues()
        {
            foreach (var entry in EntryList)
            {
                int position = entry.Column + Dimension.CurrentDimension * entry.Row;
                entry.UpdateTextSafe(Values[position]);
            }
        }

        private void LoadInfo(IMatrixInfo matrixInfo)
        {
            Id = matrixInfo.Id;
            Name = matrixInfo.Name;
            Values = matrixInfo.Values;
            Size = matrixInfo.Size;
            Date = matrixInfo.Date;

            Dimension.SetDimension(Size);
        }

        public virtual void UpdateMatrix()
        {
            OldEntryList = new List<InputEntry>(EntryList);

            ClearOldChildren();
            CreateChildren(Dimension.CurrentDimension);
            AssignLines();
            if (UpdateManager.UpdateResults != null)
            {
                UpdateManager.UpdateResults();
            }
        }
    }
}

