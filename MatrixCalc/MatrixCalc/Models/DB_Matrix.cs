using System;
using System.Collections.Generic;
using System.Linq;
using MatrixCalc.Models.Interfaces;
using PropertyChanged;
using SQLite;

namespace MatrixCalc.Models
{
    public class DB_Matrix : Matrix, IMatrixInfo
    {
        public new int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Values { get; protected set; }
        public int Size { get; protected set; }
        public string Date { get; protected set; }

        public DB_Matrix()
        {

        }

        public void SetInfo(string name, string values, int size, string date)
        {
            Name = name;
            Values = values;
            Size = size;
            Date = date;
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

        private void LoadInfo(IMatrixInfo matrixInfo)
        {
            Id = matrixInfo.Id;
            Name = matrixInfo.Name;
            Values = matrixInfo.Values;
            Size = matrixInfo.Size;
            Date = matrixInfo.Date;

            Dimension.SetDimension(Size);
        }

        private void LoadValues()
        {
            List<string> ListValues = Values.Split(';').ToList();

            foreach (var entry in EntryList)
            {
                int position = entry.Column + Dimension.CurrentDimension * entry.Row;
                entry.UpdateTextSafe(ListValues[position]);
            }
        }
    }
}

