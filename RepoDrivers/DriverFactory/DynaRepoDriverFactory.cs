using Contracts.RepoDrivers.Mechanism;
using RepoDrivers.Driver;
using RepoDrivers.Driver.PostGresDriver;
using System;
using Microsoft.Extensions.DependencyInjection;
using Contracts.SharedModels;

namespace RepoDrivers.DriverFactory
{
    public class DynaRepoDriverFactory : IDynaRepoDriverFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnectionInfoManager _connectionInfoManager;

        public DynaRepoDriverFactory(IServiceProvider serviceProvider, IConnectionInfoManager connectionInfoManager)
        {
            this._serviceProvider = serviceProvider; this._connectionInfoManager = connectionInfoManager;
        }


        public IDynaRepoDriver<IStoreMechanismDescriptor> GetRepoDriver(string mechanism, string storeGroup)
        {
            StoreMechanisms storeMechanism;
            if (!Enum.TryParse(mechanism, true, out storeMechanism))
            {
                throw new InvalidOperationException("unknown mechanism");
            }

            //TODO: replace with injection factory
            switch (storeMechanism)
            {
                case StoreMechanisms.PostGresSql: return GetPostGresDriver(storeGroup);
            }
            throw new ArgumentException("unknown Mechanism");
        }

        private IDynaRepoDriver<PostGresMechanismDescriptor> GetPostGresDriver(string storeGroup)
        {

            var objectResult = _serviceProvider.GetService<IDynaRepoDriver<PostGresMechanismDescriptor>>();
            objectResult.SetMechanismDescriptor(_connectionInfoManager.GetConnectionInfo(StoreMechanisms.PostGresSql.ToString(), storeGroup));
            return  objectResult;
        }

    }
}