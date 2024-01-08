using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using System.Threading.Tasks;
using MatrixCalc.Models;

namespace MatrixCalc
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<dbt>().Wait();
        }

        public Task<List<dbt>> GetDB_MatrixAsync()
        {
            return _database.Table<dbt>().ToListAsync();
        }

        public Task<int> SaveDB_MatrixAsync(dbt dB_Matrix)
        {
            return _database.InsertAsync(dB_Matrix);
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

