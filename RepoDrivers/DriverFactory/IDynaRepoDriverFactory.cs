using RepoDrivers.Driver;

namespace RepoDrivers.DriverFactory
{
    public interface IDynaRepoDriverFactory
    {
        IDynaRepoDriver<IStoreMechanismDescriptor> GetRepoDriver(string mechanism, string storeGroup);
    }
}