using RepoDrivers.Driver.PostGres.Entity;
using RepoDrivers.DriverFactory;
using System;

namespace RepoDrivers.Driver
{
    public interface IDynaRepoDriver<T> where T : IStoreMechanismDescriptor
    {
        void SetDescriptor(T value);
        IEntityHandler GetEntityHandler();

        IMechanismHandler GetMechanismHandler();

        IStoreHandler GetStoreHandler();

        IActionObserver observer {get;set;}
        T Descriptor {get;set;}
    }
}