using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace epDataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storeProcedure,
            U parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(
                storeProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TParent>> LoadDataMultiMap<TParent, TChild, TParem>(
            string sql,
            Func<TParent, Guid> parentKeySelector,
            Func<TParent, IList<TChild>> childSelector,
            TParem parameters,
            string splitOn = "Id",
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            var cache = new Dictionary<Guid, TParent>();

            await connection.QueryAsync<TParent, TChild, TParent>(
                sql,
                (parent, child) =>
                {
                    var key = parentKeySelector(parent);
                    if (!cache.ContainsKey(key))
                    {
                        cache.Add(key, parent);
                    }
                    var cachedParent = cache[key];
                    var children = childSelector(cachedParent);
                    children.Add(child);
                    return cachedParent;
                },
                parameters as object,
                null, true, splitOn, null, null);

            return cache.Values;
        }

        public async Task<IEnumerable<TParent>> LoadDataMultiMap<TParent, TChild, TChild2, TParem>(
            string sql,
            Func<TParent, Guid> parentKeySelector,
            Func<TParent, IList<TChild>> childSelector,
            Func<TParent, IList<TChild2>> child2Selector,
            TParem parameters,
            string splitOn = "Id",
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            var cache = new Dictionary<Guid, TParent>();

            await connection.QueryAsync<TParent, TChild, TChild2, TParent>(
                sql,
                (parent, child, child2) =>
                {
                    var key = parentKeySelector(parent);
                    if (!cache.ContainsKey(key))
                    {
                        cache.Add(key, parent);
                    }
                    var cachedParent = cache[key];
                    var children = childSelector(cachedParent);
                    children.Add(child);
                    var children2 = child2Selector(cachedParent);
                    children2.Add(child2);
                    return cachedParent;
                },
                parameters as object,
                null, true, splitOn, null, null);

            return cache.Values;
        }

        public async Task SaveData<T>(
            string storeProcedure,
            T parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            await connection.ExecuteAsync(
                storeProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
