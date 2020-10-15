using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApp.Interface;
using TestApp.Model;
using Xamarin.Forms;

namespace TestApp.Helpers
{
    public static class DBHelper
    {
        
        public static void CreateTables()
        {
            SQLiteConnection dbConn = DependencyService.Get<IDBInterface>().GetConnection();
            var StudentTableInfo = dbConn.GetTableInfo(nameof(StudentInfo));
            if (!StudentTableInfo.Any())
            {
                dbConn.CreateTable<StudentInfo>();
            }

            var AddressTableInfo = dbConn.GetTableInfo(nameof(AddressInfo));
            if (!AddressTableInfo.Any())
            {
                dbConn.CreateTable<AddressInfo>();
            }

            var DocumentsTableInfo = dbConn.GetTableInfo(nameof(DocumentsInfo));
            if (!DocumentsTableInfo.Any())
            {
                dbConn.CreateTable<DocumentsInfo>();
            }

            var UserTableInfo = dbConn.GetTableInfo(nameof(User));
            if (!UserTableInfo.Any())
            {
                dbConn.CreateTable<User>();
            }
        }
        public static void DeleteTables()
        {
            SQLiteConnection dbConn = DependencyService.Get<IDBInterface>().GetConnection();
            dbConn.DropTable<StudentInfo>();
            dbConn.DropTable<AddressInfo>();
            dbConn.DropTable<DocumentsInfo>();
            dbConn.DropTable<User>();
        }

    }
}
