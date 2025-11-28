using System.Data;
using Dapper;

namespace MMC_Pro_Edition.Models
{
    public class DBManager
    {
        private readonly IConfiguration _config;
        private readonly DapperContext _dap;
        public DBManager(IConfiguration config)
        {
            _config = config;

            _dap = new DapperContext(_config);
        }
        public async Task<IEnumerable<T>> GetDataListWithQueryAndParam<T>(string query, object? parameters = null)
        {
            try
            {
                using (var con = _dap.CreateConnection())
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    return await con.QueryAsync<T>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing query.", ex);
            }
        }
        public async Task<T> GetSingleItemDatatWithQueryAndParam<T>(string query, object? parameters = null)
        {
            try
            {
                using (var con = _dap.CreateConnection())
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    return await con.QuerySingleOrDefaultAsync<T>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing query.", ex);
            }
        }

        public async Task<IEnumerable<T>> ExecuteQueryList<T>(string query)
        {
            try
            {
                using (var con = _dap.CreateConnection())
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    return await con.QueryAsync<T>(query);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing query.", ex);
            }
        }
        public async Task<T> ExecuteQuery<T>(string query)
        {
            try
            {
                using (var con = _dap.CreateConnection())
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    return await con.QuerySingleOrDefaultAsync<T>(query);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing query.", ex);
            }
        }
        public async Task<int> ExecuteQueryModify(string query)
        {
            try
            {
                using (var con = _dap.CreateConnection())
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    return await con.ExecuteAsync(query);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing query.", ex);
            }
        }
        public async Task<T> ExecuteQuery<T>(string query, object param)
        {
            try
            {
                using (var con = _dap.CreateConnection())
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (var transaction = con.BeginTransaction())
                    {
                        try
                        {
                            var result = await con.QuerySingleAsync<T>(query, param, transaction);
                            transaction.Commit();
                            return result;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing query with return value.", ex);
            }
        }


        public async Task<int> GetMaxId(string tableName, string idColumn)
        {
            try
            {
                using (var con = _dap.CreateConnection())
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string query = $"SELECT MAX({idColumn}) FROM {tableName}";

                    return await con.ExecuteScalarAsync<int>(query);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving max ID from {tableName}.", ex);
            }
        }
        public async Task<int> ExecuteInsertQueryandParam(string query, object? param = null)
        {
            try
            {
                using (var con = _dap.CreateConnection())
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    using (var transaction = con.BeginTransaction())
                    {
                        try
                        {
                            var rowsAffected = await con.ExecuteAsync(query, param, transaction);
                            transaction.Commit();
                            return rowsAffected; // number of rows inserted/updated/deleted
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing non-query (INSERT/UPDATE/DELETE).", ex);
            }
        }

    }

}
