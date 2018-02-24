namespace Contracts.SharedModels
{
    public interface IConnectionInfoManager
    {
        ConnectionInfo GetConnectionInfo(string key);
        ConnectionInfo GetConnectionInfo(string mechanims, string storeGroup);
    }
}