using DynamicRepo.Business.Implementations.PostGres;
using DynamicRepo.Business.Interfaces;
using DynamicRepo.Common.Models;
using DynamicRepo.Data.DataStores.Drivers;
using DynamicRepo.ServiceConfiguration;
using System.Collections.Generic;

namespace DynamicRepo.Business
{
    public class PostGresSqlStoreOperations : IStoreOperations
    {
        private readonly ISqlDal _sqlDal;
        private readonly IConfig _config;

        public PostGresSqlStoreOperations(ISqlDal sqlDal,IConfig config)
        {
            this._sqlDal = sqlDal;
            this._config = config;
        }

        public bool CreateEntity(CreateEntityModel createEntityModel)
        {
            var sql = PostGresScripts.GenerateCreateTableScript(createEntityModel);
            _sqlDal.RunSQlExecuteNonQuery(sql, _config.PGConnectionString);
            return true;
        }

        public bool CreateStoreGroup(CreateStoreModel createStoreModel)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteEntity(string entityUID)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteEntityCollection(List<string> entityUID)
        {
            throw new System.NotImplementedException();
        }

        public object GetEntityAttribute(string entityUID, List<string> attributeNames)
        {
            throw new System.NotImplementedException();
        }

        public object GetEntityAttributeCollection(string entityUID, List<string> attributeNames)
        {
            throw new System.NotImplementedException();
        }

        public object GetEntityObject(string entityUID)
        {
            throw new System.NotImplementedException();
        }

        public object GetEntityObjectCollection(List<string> entityUID)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveStoreGroup(CreateStoreModel createStoreModel)
        {
            throw new System.NotImplementedException();
        }

        public bool StoreEntity(string entityUID, object jsonObject)
        {
            throw new System.NotImplementedException();
        }

        public bool StoreEntityCollection(string entityUID, List<object> jsonObjectCollection)
        {
            throw new System.NotImplementedException();
        }

        public bool UpsertEntity(string entityUID, object jsonObject)
        {
            throw new System.NotImplementedException();
        }

        public bool UpsertEntityCollection(string entityUID, List<object> jsonObjectCollection)
        {
            throw new System.NotImplementedException();
        }
    }
}