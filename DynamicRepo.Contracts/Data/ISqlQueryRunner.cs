using System.Data;

namespace DynamicRepo.Contracts.Data
{
    public interface ISqlQueryRunner<TConnection,TCommand>
    {
        void RunSQlExecuteNonQuery(string sql, string connectionString = "Server=127.0.0.1;Port=5432;Database=DataRepo;Userid=postgres;\r\nPassword=root;");
        DataTable RunSQlExecuteReader(string sql, string connectionString = "Server=127.0.0.1;Port=5432;Database=DataRepo;Userid=postgres;\r\nPassword=root;");
    }
}