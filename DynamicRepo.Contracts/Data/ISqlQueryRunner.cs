namespace DynamicRepo.Contracts.Data
{
    public interface ISqlQueryRunner
    {
        void RunSQlExecuteNonQuery(string sql, string connectionString);
        object RunSQlExecuteReader(string sql, string connectionString);
    }
}