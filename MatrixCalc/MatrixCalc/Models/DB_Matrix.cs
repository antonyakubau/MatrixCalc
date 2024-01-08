using System;
using System.Collections.Generic;
using MatrixCalc.Models.Interfaces;

namespace MatrixCalc.Models
{
    public class DB_Matrix : Matrix, IMatrixInfo
    {

        public new int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public int Dimension { get; set; }
        public string Date { get; set; }

        public DB_Matrix()
        {

        }


        public virtual void Load(IMatrixInfo matrixInfo)
        {
            LoadInfo(matrixInfo);

            LoadValues();

            UpdateMatrix(matrixInfo.Dimension);

            //ClearOldChildren();
            //LoadChildren(matrixInfo.Size);

        }

        private void LoadValues()
        {
            foreach (var entry in OldEntryList)
            {
                //entry.Text = 
            }
        }

        private void LoadInfo(IMatrixInfo matrixInfo)
        {
            Id = matrixInfo.Id;
            Name = matrixInfo.Name;
            Data = matrixInfo.Data;
            Dimension = matrixInfo.Dimension;
            Date = matrixInfo.Date;
        }


        private void LoadChildren(int currentMatrixDimension)
        {
            for (int row = 0; row <= currentMatrixDimension; row++)
            {
                for (int column = 0; column <= currentMatrixDimension; column++)
                {
                    LoadChild(currentMatrixDimension, row, column);
                }

            }
        }

        private void LoadChild(int currentMatrixDimension, int row, int column)
        {
            //throw new NotImplementedException();
        }
    }
}

