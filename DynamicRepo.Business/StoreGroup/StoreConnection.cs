using DynamicRepo.Contracts.Business;
namespace DynamicRepo.Business.StoreGroup
{
    public class StoreConnection : IStoreConnection
    {
        public StoreConnection()
        {

        }
        public string ConnectionString
        {
            get { return "Server=127.0.0.1;Port=5432;Database=DataRepo;Userid=postgres;\r\nPassword=root;"; }
            set => throw new System.NotImplementedException();
        }

        public IStoreConnection GetStoreConnection(string storeGroupId=null)
        {
            if(storeGroupId==null)
            return new StoreConnection();
            return null;
        }
    }
}