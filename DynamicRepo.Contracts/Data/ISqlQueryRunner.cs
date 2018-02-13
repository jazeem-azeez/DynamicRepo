using DynamicRepo.Contracts.Business;
using System.Data;
using System.Threading.Tasks;

namespace DynamicRepo.Contracts.Data
{
    public interface ISqlQueryRunner<TConnection,TCommand>
    {
        Task<bool> RunSQlExecuteNonQueryAsync(string sql, IStoreConnection connection );
        DataTable RunSQlExecuteReader(string sql, IStoreConnection connection);
    }
}