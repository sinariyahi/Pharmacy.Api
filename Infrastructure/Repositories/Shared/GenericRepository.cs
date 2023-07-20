using Common.DBHelper;
using Contracts.Interface.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Shared
{
    public class GenericRepository<T, U> : IGenericRepository<T, U> where T : class where U : class
    {


        private readonly IConnectionUtility connectionUtility;
        public GenericRepository(IConnectionUtility connectionUtility)
        {
            this.connectionUtility = connectionUtility;
        }
        public Task Delete(string spName, object parameters = null)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string spName, long id)
        {
            throw new NotImplementedException();

        }

        public async Task<U> Get(string spName, object parameters = null)
        {
            using (var dapper = connectionUtility.NewConnection())
            {
                return await dapper.QueryFirstOrDefaultAsync<U>(spName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<T>> GetAllSingle(string spName, object parameters = null)
        {
            using (var dapper = connectionUtility.NewConnection())
            {

                return await dapper.QueryAsync<T>(spName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<DataTable> GetDataTable(string spName, object parameters = null)
        {
            var dt = new DataTable();
            using (var dapper = connectionUtility.NewConnection())
            {
                try
                {

                    var re = await dapper.ExecuteReaderAsync(spName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    dt.Load(re);
                }
                catch (Exception ex)
                {

                    throw;
                }


            }
            return dt;
        }
        public async Task<List<object>> GetMultiSelect(string spName, short outputCounts, object parameters = null)
        {

            var res = new List<object>();
            using (var dapper = connectionUtility.NewConnection())
            {

                var results = await dapper.QueryMultipleAsync(spName, parameters, commandType: System.Data.CommandType.StoredProcedure);//.QueryMultipleAsync<T>(spName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                for (int i = 0; i < outputCounts; i++)
                {
                    var g = results.ReadAsync<dynamic>().Result;
                    res.Add(g);
                }
                return res;
            }

        }
        public async Task<(IEnumerable<T>, long)> GetAll(string spName, object parameters = null)
        {
            using (var dapper = connectionUtility.NewConnection())
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.AddDynamicParams(parameters);
                dynamicParameters.Add("recordCount", dbType: System.Data.DbType.Int64, direction: System.Data.ParameterDirection.Output);
                var data = await dapper.QueryAsync<T>(spName, dynamicParameters, commandType: System.Data.CommandType.StoredProcedure);
                var rowCount = Convert.ToInt64(dynamicParameters.Get<long>("recordCount"));
                return (data, rowCount);
                //return (data,10);
            }
        }

        public Task<U> GetById(string spName, long id)
        {
            throw new NotImplementedException();
        }

        public async Task<object> Insert(string spName, object parameters = null)
        {
            using (var dapper = connectionUtility.NewConnection())
            {
                return await dapper.ExecuteScalarAsync(spName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

        }
        public async Task<object> InsertWithTran(string spName, object parameters = null)
        {
            using (var connection = connectionUtility.NewConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var result = await connection.ExecuteScalarAsync(spName, parameters, transaction: transaction, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != null)
                        transaction.Commit();
                    else
                        transaction.Rollback();

                    return result;
                }
            }

        }
        public Task Update(string spName, object parameters = null)
        {
            throw new NotImplementedException();
        }
    }
    public class Rolee
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
    }

}


