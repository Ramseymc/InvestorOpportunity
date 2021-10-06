using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary
{
    public class QueryParams
    {
        public string Query { get; set; }
        public List<RecordValue> Records { get; set; } = new List<RecordValue>();
    }


    public class RecordValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }



    public interface IDataAccessRepository
    {
        Task<IEnumerable<T>> GetAll<T>(QueryParams param) where T : class;
        Task<IEnumerable<T>> GetWhere<T>(QueryParams param) where T : class;
        Task<T> GetById<T>(QueryParams param) where T : class;
        Task<T> Create<T>(QueryParams param, T entity) where T : class;
        Task<T> Update<T>(QueryParams param, T entity) where T : class;
        Task<T> Delete<T>(QueryParams param) where T : class;
        Task Execute(QueryParams param);
    }


    public class DataAccessRepository : IDataAccessRepository
    {
        private readonly string _connStr;

        public DataAccessRepository()
        {
            //_connStr = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            _connStr = ContainerConfig.DBConnection;
        }

        public async Task<IEnumerable<T>> GetAll<T>(QueryParams param) where T : class
        {
            using (var conn = new SqlConnection(_connStr))
            {
                var queryParams = new DynamicParameters();

                foreach (var item in param.Records)
                {
                    queryParams.Add(item.Name, item.Value);
                }

                await conn.OpenAsync();

                var modelData = await conn.QueryAsync<T>(param.Query, queryParams, commandType: CommandType.StoredProcedure);

                return modelData;
            }
        }

       
        public async Task<IEnumerable<T>> GetWhere<T>(QueryParams param) where T : class
        {
            using (var conn = new SqlConnection(_connStr))
            {
                var queryParams = new DynamicParameters();

                foreach (var item in param.Records)
                {
                    queryParams.Add(item.Name, item.Value);
                }

                await conn.OpenAsync();

                var modelData = await conn.QueryAsync<T>(param.Query, queryParams, commandType: CommandType.StoredProcedure);

                return modelData;
            }
        }


        public async Task<T> GetById<T>(QueryParams param) where T : class
        {
            using (var conn = new SqlConnection(_connStr))
            {
                var queryParams = new DynamicParameters();

                foreach (var item in param.Records)
                {
                    queryParams.Add(item.Name, item.Value);
                }

                await conn.OpenAsync();

                var modelData = await conn.QueryAsync<T>(param.Query, queryParams, commandType: CommandType.StoredProcedure);

                return modelData.SingleOrDefault();
            }

        }

        public async Task<T> Create<T>(QueryParams param, T modelData) where T : class
        {
            using (var conn = new SqlConnection(_connStr))
            {
                var queryParams = new DynamicParameters();

                var type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    queryParams.Add(property.Name, property.GetValue(modelData));
                }

                foreach (var item in param.Records)
                {
                    queryParams.Add(item.Name, item.Value);
                }

                await conn.OpenAsync();

                var result = await conn.QueryAsync<T>(param.Query, queryParams, commandType: CommandType.StoredProcedure);

                return result.SingleOrDefault();

            }
        }


        public async Task<T> Update<T>(QueryParams param, T modelData) where T : class
        {
            using (var conn = new SqlConnection(_connStr))
            {
                var queryParams = new DynamicParameters();

                var type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    queryParams.Add(property.Name, property.GetValue(modelData));
                }

                foreach (var item in param.Records)
                {
                    queryParams.Add(item.Name, item.Value);
                }

                await conn.OpenAsync();

                var result = await conn.QueryAsync<T>(param.Query, queryParams, commandType: CommandType.StoredProcedure);

                return result.SingleOrDefault();
            }
        }


        public async Task<T> Delete<T>(QueryParams param) where T : class
        {
            using (var conn = new SqlConnection(_connStr))
            {
                var queryParams = new DynamicParameters();

                foreach (var item in param.Records)
                {
                    queryParams.Add(item.Name, item.Value);
                }

                await conn.OpenAsync();

                var result = await conn.QueryAsync<T>(param.Query, queryParams, commandType: CommandType.StoredProcedure);

                return result.SingleOrDefault();
            }

        }


        public async Task Execute(QueryParams param)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                var queryParams = new DynamicParameters();

                foreach (var item in param.Records)
                {
                    queryParams.Add(item.Name, item.Value);
                }

                await conn.OpenAsync();

                var result = await conn.ExecuteAsync(param.Query, queryParams, commandType: CommandType.StoredProcedure);
            }

        }


    }

}
