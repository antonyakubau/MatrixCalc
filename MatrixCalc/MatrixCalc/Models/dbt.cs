using System;
using MatrixCalc.Models.Interfaces;
using SQLite;

namespace MatrixCalc.Models
{
	public class dbt : IMatrixInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Values { get; set; }
        public int Size { get; set; }
        public string Date { get; set; }
        public dbt()
		{
		}
	}
}

