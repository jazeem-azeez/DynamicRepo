using RepoDrivers.Driver.PostGres.Entity;
using System;
using Contracts.SharedModels;

namespace RepoDrivers.Driver.PostGresDriver
{
    public class PostGresDynaRepoDriver : IDynaRepoDriver<PostGresMechanismDescriptor>
    {
        private readonly IEntityHandler<PostGresMechanismDescriptor> _entityHandler;

        public PostGresDynaRepoDriver(IEntityHandler<PostGresMechanismDescriptor> entityHandler)
        {
            this._entityHandler = entityHandler;
        }

        public PostGresMechanismDescriptor StoreMechanismDescriptor { get; set; }
        public IActionObserver observer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEntityHandler<PostGresMechanismDescriptor> GetEntityHandler()
        {
            _entityHandler.SetStoreMechanismDescriptor(StoreMechanismDescriptor);
            return _entityHandler;
        }

        public IMechanismHandler GetMechanismHandler()
        {
            throw new NotImplementedException();
        }

        public IStoreHandler GetStoreHandler()
        {
            throw new NotImplementedException();
        }

        public void SetMechanismDescriptor(ConnectionInfo connectionInfoObject)
        {
            //todo: use auto mapper if necessary 
            var iStoreMechanismDescriptor = connectionInfoObject.ConnectionInfoObject as IStoreMechanismDescriptor;
            StoreMechanismDescriptor = iStoreMechanismDescriptor as PostGresMechanismDescriptor;
        }
    }
}