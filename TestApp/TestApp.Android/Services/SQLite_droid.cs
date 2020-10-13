using System;
using System.IO;
using Android.OS;
using SQLite;
using TestApp.Droid.Services;
using TestApp.Interface;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(SQLite_droid))]
namespace TestApp.Droid.Services
{
    public class SQLite_droid : IDBInterface
    {
        public SQLiteConnection conn;
        public SQLiteConnection GetConnection()
        {
            InitializeDB();
            return conn;
        }

        public void InitializeDB()
        {
            string filename = "TestDB.db3";
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
            conn = new SQLite.SQLiteConnection(path);
        }
    }
}