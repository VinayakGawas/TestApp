using System.Collections.Generic;

namespace TestApp.Repo
{
    public interface IGenericRepo<T>
    {
        void Delete(string id);
        void Insert(T a);
        void InsertAll(IEnumerable<T> a);
        void InsertOrReplace(T a);
        SQLite.TableQuery<T> QueryTable();
        void Update(T a);
    }
}