using DynamicRepo.Contracts.Business;
using DynamicRepo.Contracts.Business.Constants;
using DynamicRepo.Contracts.Business.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace DynamicRepo.Business.Entity
{
    public class EntityBusiness : IEntityBusiness
    {
        private readonly Func<Mechanisms, IStoreDriverOperations> _dataServiceFactory;
        private readonly IStoreConnection _storeConnection;

        public EntityBusiness(Func<Mechanisms, IStoreDriverOperations> dataServiceFactory, IStoreConnection storeConnection)
        {
            this._dataServiceFactory = dataServiceFactory;
            this._storeConnection = storeConnection;
        }

        public Task<bool> CreateEntity(JObject jObjectCreatePayLoad, string storeGroupId, string mechanism)
        {
            Contract.Ensures(jObjectCreatePayLoad.HasValues && !string.IsNullOrWhiteSpace(jObjectCreatePayLoad.ToString()));
            Contract.Assert(mechanism == jObjectCreatePayLoad[nameof(mechanism)].ToString(), "Mismatch betweeen mechanism and payload's mechanism");
            try
            {
                var mechanismEnum = GetMechanismEnum(mechanism);
                var driver = _dataServiceFactory(mechanismEnum);

                var connection = _storeConnection.GetStoreConnection(storeGroupId);

                return driver.CreateEntiyGroup(jObjectCreatePayLoad, connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Mechanisms GetMechanismEnum(string mechanism)
        {
            return (Mechanisms)Enum.Parse(typeof(Mechanisms), mechanism);
        }

        public Task<bool> CreateEntity(JObject jObjectCreatePayLoad, string storeGroup, string mechanism, string entityname, string attributeName)
        {
            Contract.Ensures(jObjectCreatePayLoad.HasValues && !string.IsNullOrWhiteSpace(jObjectCreatePayLoad.ToString()));
            Contract.Assert(mechanism == jObjectCreatePayLoad[nameof(mechanism)].ToString(), "Mismatch betweeen mechanism and payload's mechanism");
            try
            {
                var mechanismEnum = GetMechanismEnum(mechanism);
                var driver = _dataServiceFactory(mechanismEnum);

                var connection = _storeConnection.GetStoreConnection(storeGroup);

                return driver.CreateEntiyGroup(jObjectCreatePayLoad, entityname,attributeName, connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> CreateEntity(JObject jObjectCreatePayLoad, string storeGroup, string mechanism, string entityname)
        {
            Contract.Ensures(jObjectCreatePayLoad.HasValues && !string.IsNullOrWhiteSpace(jObjectCreatePayLoad.ToString()));
            Contract.Assert(mechanism == jObjectCreatePayLoad[nameof(mechanism)].ToString(), "Mismatch betweeen mechanism and payload's mechanism");
            try
            {
                var mechanismEnum = GetMechanismEnum(mechanism);
                var driver = _dataServiceFactory(mechanismEnum);

                var connection = _storeConnection.GetStoreConnection(storeGroup);

                return driver.CreateEntiyGroup(jObjectCreatePayLoad, entityname, connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}