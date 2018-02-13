using RepoDrivers.Driver.PostGres.Entity;
using RepoDrivers.DriverFactory;

namespace RepoDrivers.Driver
{
    public interface IDynaRepoDriver<T> where T : IStoreMechanismDescriptor
    {
        IEntityHandler GetEntityHandler(T descriptor);

        IMechanismHandler GetMechanismHandler(T descriptor);

        IStoreHandler GetStoreHandler(T descriptor);

        IActionObserver observer {get;set;}
    }
}