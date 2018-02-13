using DynamicRepo.Contracts.Business;
using DynamicRepo.Contracts.Business.Constants;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace DynamicRepo.Business.StoreGroup
{
    public class StoreGroupBusiness : IStoreGroupBusiness
    {
        private readonly Func<Mechanisms, IStoreDriverOperations> _dataServiceFactory;
        private readonly IStoreConnection _storeConnection;

        public StoreGroupBusiness(Func<Mechanisms, IStoreDriverOperations> dataServiceFactory,IStoreConnection storeConnection)
        {
            this._dataServiceFactory = dataServiceFactory;
            this._storeConnection = storeConnection;
        }

        public Task<bool> CreateDataStore(JObject storeCreatejObject, string mechanism)
        {
            var mechanismFromBody = storeCreatejObject.GetValue(nameof(mechanism));

            Contract.Ensures(mechanismFromBody.HasValues && !string.IsNullOrWhiteSpace(mechanismFromBody.ToString()));
            Contract.Assert(mechanism == mechanismFromBody.ToString(), "Mismatch betweeen mechnism and payload ");
            try
            {

                var driver = _dataServiceFactory(Mechanisms.PostGres);
                var connection = _storeConnection.GetStoreConnection();
                return driver.CreateDataStore(storeCreatejObject,connection);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EventSubscriptionRegistration(JObject EventFilterExpression)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveStore(string StoreId)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateMechanism(string mechanism)
        {
            throw new System.NotImplementedException();
        }
    }
}