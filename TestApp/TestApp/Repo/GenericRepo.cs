﻿using SQLite;
using System.Collections.Generic;
using TestApp.Interface;
using Xamarin.Forms;

namespace TestApp.Repo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : new()
    {
        public GenericRepo()
        {

        }
        public void Insert(T a)
        {
            DependencyService.Get<IDBInterface>().GetConnection().Insert(a);
        }

        public void InsertOrReplace(T a)
        {
            DependencyService.Get<IDBInterface>().GetConnection().InsertOrReplace(a);
        }
        public void InsertAll(IEnumerable<T> a)
        {
            DependencyService.Get<IDBInterface>().GetConnection().InsertAll(a);
        }
        public void Update(T a)
        {
            DependencyService.Get<IDBInterface>().GetConnection().Update(a);
        }
        public TableQuery<T> QueryTable()
        {
            var a =  DependencyService.Get<IDBInterface>().GetConnection().Table<T>();
            return a;
        }

        public void Delete(string id)
        {
            DependencyService.Get<IDBInterface>().GetConnection().Delete<T>(id);
        }
    }
}
