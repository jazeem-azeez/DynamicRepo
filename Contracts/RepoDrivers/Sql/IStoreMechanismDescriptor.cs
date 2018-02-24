using Contracts.RepoDrivers.Mechanism;

namespace RepoDrivers
{
    public interface IStoreMechanismDescriptor
    {
        string ConnectionString { get; set; }
        string EndPoint { get; set; }
        StoreMechanisms Mechanism { get; }
        string StoreGroupName { get; set; }
        string User { get; set; }
        string Password { get; set; }
    }
}