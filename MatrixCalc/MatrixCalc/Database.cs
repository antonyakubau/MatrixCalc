using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using System.Threading.Tasks;
using MatrixCalc.Models;
using MatrixCalc.Models.Interfaces;

namespace MatrixCalc
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            //_database.DropTableAsync<MatrixInfo>().Wait();
            _database.CreateTableAsync<MatrixInfo>().Wait();
        }

        public Task<List<MatrixInfo>> GetDbMatricesAsync()
        {
            return _database.Table<MatrixInfo>().ToListAsync();
        }

        public Task<int> SaveDbMatrixAsync(IMatrixInfo dB_Matrix)
        {
            return _database.InsertAsync(new MatrixInfo(dB_Matrix));
        }

        public Task<int> DeleteDbMatrixAsync(int id)
        {
            return _database.DeleteAsync<MatrixInfo>(id);
        }
    }

    public static class Constants
    {
        public const string DatabaseFilename = "DBMatrix.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }

}

