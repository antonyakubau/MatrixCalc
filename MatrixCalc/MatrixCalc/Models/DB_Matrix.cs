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

            LoadValues();

            UpdateMatrix(matrixInfo.Size);

        }

        private void LoadValues()
        {
            foreach (var entry in EntryList)
            {
                entry.UpdateTextSafe(Values[0]);
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
            
        }
    }
}

