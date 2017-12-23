using Npgsql;
using System;
using System.Data;

namespace DynamicRepo.Data
{
    //General Pattern is for all sql dapters
    public class PostGresSqlQueryRunner
    {
        public void RunSQlExecuteNonQuery(string sql, string connectionString= @"Server=127.0.0.1;Port=5432;Database=DataRepo;Userid=postgres;
Password=root;Protocol=3;Pooling=true;MinPoolSize=1;MaxPoolSize=100;ConnectionLifeTime=15;")
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RunSQlExecuteReader(string sql, string connectionString = @"Server=127.0.0.1;Port=5432;Database=DataRepo;Userid=postgres;
Password=root;")
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
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