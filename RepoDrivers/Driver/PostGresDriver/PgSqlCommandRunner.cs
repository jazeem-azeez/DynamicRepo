using Newtonsoft.Json.Linq;
using Npgsql;
using RepoDrivers.Driver.PostGres.Entity;
using RepoDrivers.DriverFactory;
using System;
using System.Data;

namespace RepoDrivers.Driver.PostGres
{
    public class PgSqlCommandRunner : SqlCommandRunnerBase, ISqlCommandRunner<PostGresMechanismDescriptor>
    {
        public JToken RunScalarCommand(string command, PostGresMechanismDescriptor mechanism)
        {
            try
            {
                int affectedEntries = 0;
                using (var connection = new NpgsqlConnection(mechanism.ConnectionString))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(command, connection))
                    {
                        affectedEntries = cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return JToken.FromObject(affectedEntries);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JToken RunVectorCommand(string command, PostGresMechanismDescriptor mechanism)
        {
            try
            {
                using (var connection = new NpgsqlConnection(mechanism.ConnectionString))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(command, connection))
                    {
                        DataTable dt = new DataTable();
                        NpgsqlDataAdapter objDataAdapter = new NpgsqlDataAdapter(cmd);
                        objDataAdapter.Fill(dt);
                        return DataTableToJsonObject(dt);
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