using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TestApp.Interface
{
    public interface IDBInterface
    {
        SQLiteConnection GetConnection();
        void InitializeDB();
    }
}
