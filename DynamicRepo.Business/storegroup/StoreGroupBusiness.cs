using DynamicRepo.Contracts.Business;
using DynamicRepo.Contracts.Business.Constants;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace DynamicRepo.Business.storegroup
{
    public class StoreGroupBusiness : IStoreGroupBusiness
    {
        private readonly Func<Mechanisms, IStoreDriverOperations> _dataServiceFactory;

        public StoreGroupBusiness(Func<Mechanisms, IStoreDriverOperations> dataServiceFactory)
        {
            this._dataServiceFactory = dataServiceFactory;
        }

        public Task<bool> CreateDataStore(JObject storeCreatejObject, string mechanism)
        {
            var mechanismFromBody = storeCreatejObject.GetValue("mechansim");

            Contract.Ensures(mechanismFromBody.HasValues && !string.IsNullOrWhiteSpace(mechanismFromBody.ToString()));
            Contract.Assert(mechanism == mechanismFromBody.ToString(), "Mismatch betweeen mechnism and payload ");

            var driver = _dataServiceFactory(Mechanisms.PostGres);
            return driver.CreateDataStore(storeCreatejObject);
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