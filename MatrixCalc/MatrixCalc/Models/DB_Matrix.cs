using System;
using System.Collections.Generic;
using System.Linq;
using MatrixCalc.Models.Interfaces;
using SQLite;

namespace MatrixCalc.Models
{
    public class DB_Matrix : Matrix
    {

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
                List<string> ListValues = Values.Split(';').ToList();

                int position = entry.Column + Dimension.CurrentDimension * entry.Row;
                entry.UpdateTextSafe(ListValues[position]);
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

