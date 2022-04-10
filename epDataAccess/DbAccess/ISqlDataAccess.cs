
using System.Data;

namespace epDataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storeProcedure, U parameters, string connectionId = "Default");
        Task<IEnumerable<TParent>> LoadDataMultiMap<TParent, TChild, TParam>(
            string sql,
            Func<TParent, Guid> parentKeySelector,
            Func<TParent, IList<TChild>> childSelector,
            TParam parameters,
            string splitOn = "Id",
            string connectionId = "Default");
        Task<IEnumerable<TParent>> LoadDataMultiMap<TParent, TChild, TChild2, TParam>(
            string sql,
            Func<TParent, Guid> parentKeySelector,
            Func<TParent, IList<TChild>> childSelector,
            Func<TParent, IList<TChild2>> child2Selector,
            TParam parameters,
            string splitOn = "Id",
            string connectionId = "Default");
        Task SaveData<T>(string storeProcedure, T parameters, string connectionId = "Default");
    }
}