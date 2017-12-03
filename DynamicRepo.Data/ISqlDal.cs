using System.Data;

namespace DynamicRepo.Data.DataStores.Drivers
{
    public interface ISqlDal
    {
        void RunSQlExecuteNonQuery(string sql, string connectionString);

        DataSet RunSQlExecuteReader(string sql, string connectionString);

        object RunSQlExecuteScalar(string sql, string connectionString);
    }
}