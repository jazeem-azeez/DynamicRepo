using DynamicRepo.Contracts.Business;
using DynamicRepo.Contracts.Data;
using Npgsql;
using System;
using System.Data;
using System.Threading.Tasks;
using ZeroConfigServiceSettings;

namespace DynamicRepo.Data
{
    //General Pattern is for all sql dapters
    public class PostGresSqlQueryRunner : SqlCrudHelpers, ISqlQueryRunner<NpgsqlConnection, NpgsqlCommand>
    {
        private readonly IConfigurationSettings _configurationSettings;

        public PostGresSqlQueryRunner(IConfigurationSettings configurationSettings)
        {
            this._configurationSettings = configurationSettings;
        }

      

        public async Task<bool> RunSQlExecuteNonQueryAsync(string sql, IStoreConnection storeConnection)
        {
            try
            {
                using (var connection = new NpgsqlConnection(storeConnection.ConnectionString))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {
                        await cmd.ExecuteNonQueryAsync();
                    }
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RunSQlExecuteReader(string sql, IStoreConnection storeConnection)
        {
            try
            {
                using (var connection = new NpgsqlConnection(storeConnection.ConnectionString))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {
                        DataTable dt = new DataTable();
                        NpgsqlDataAdapter objDataAdapter = new NpgsqlDataAdapter(cmd);
                        objDataAdapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}