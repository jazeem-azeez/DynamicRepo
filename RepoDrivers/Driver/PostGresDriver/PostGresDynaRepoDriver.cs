using RepoDrivers.Driver.PostGres.Entity;
using RepoDrivers.DriverFactory;
using RepoDrivers.Sql.PostGres;
using System;

namespace RepoDrivers.Driver.PostGresDriver
{
    public class PostGresDynaRepoDriver<T>: IDynaRepoDriver<T> where T :class ,IStoreMechanismDescriptor
    {
        private readonly IEntityHandler<T> _entityHandler;

        public PostGresDynaRepoDriver(IEntityHandler<T> entityHandler)
        {
            this._entityHandler = entityHandler;
        }
        public T Descriptor { get; set; }
        public IActionObserver observer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEntityHandler<T> GetEntityHandler()
        {
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

        public void SetDescriptor(T value)
        {
            throw new NotImplementedException();
        }
    }
}