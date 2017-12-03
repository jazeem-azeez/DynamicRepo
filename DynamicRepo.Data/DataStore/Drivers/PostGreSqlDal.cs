using DynamicRepo.Data.DataStores.Drivers;
using Npgsql;
using System;
using System.Data;

namespace DynamicRepo.Data
{
    public class PostGreSqlDal : ISqlDal
    {
        public void RunSQlExecuteNonQuery(string sql, string connectionString)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand()
                    { Connection = connection, CommandType = CommandType.Text, CommandText = sql };
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RunSQlExecuteReader(string sql, string connectionString)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand()
                    { Connection = connection, CommandType = CommandType.Text, CommandText = sql };
                    DataSet ds = new DataSet();
                    NpgsqlDataAdapter objDataAdapter = new NpgsqlDataAdapter(cmd);
                    objDataAdapter.Fill(ds);
                    cmd.Dispose();
                    connection.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object RunSQlExecuteScalar(string sql, string connectionString)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand()
                    { Connection = connection, CommandType = CommandType.Text, CommandText = sql };
                    var obj = cmd.ExecuteScalar();
                    cmd.Dispose();
                    connection.Close();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}