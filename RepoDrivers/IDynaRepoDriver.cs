using Contracts.SharedModels;
using RepoDrivers.Driver.PostGres.Entity;
using RepoDrivers.DriverFactory;

namespace RepoDrivers.Driver
{
    public interface IDynaRepoDriver<out T> where T : class, IStoreMechanismDescriptor
    {
        T StoreMechanismDescriptor { get; }

        IActionObserver observer { get; set; }

        IEntityHandler<T> GetEntityHandler();

        IMechanismHandler GetMechanismHandler();

        IStoreHandler GetStoreHandler();
        void SetMechanismDescriptor(ConnectionInfo connectionInfoObject);
    }
}