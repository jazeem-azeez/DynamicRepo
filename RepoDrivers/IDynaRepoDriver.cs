using RepoDrivers.Driver.PostGres.Entity;
using RepoDrivers.DriverFactory;

namespace RepoDrivers.Driver
{
    public interface IDynaRepoDriver<T> where T : class, IStoreMechanismDescriptor
    {
        T Descriptor { get; set; }

        IActionObserver observer { get; set; }

        IEntityHandler<T> GetEntityHandler();

        IMechanismHandler GetMechanismHandler();

        IStoreHandler GetStoreHandler();

        void SetDescriptor(T value);
    }
}