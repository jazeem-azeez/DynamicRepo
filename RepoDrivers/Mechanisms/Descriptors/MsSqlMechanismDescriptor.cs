using Contracts.RepoDrivers.Mechanism;
using RepoDrivers.DriverFactory;

namespace RepoDrivers
{
    public class MsSqlMechanismDescriptor : IStoreMechanismDescriptor
    {
        public string ConnectionString { get; set; }
        public string EndPoint { get; set; }

        public StoreMechanisms Mechanism { get { return StoreMechanisms.MsSql; } }

        public string StoreGroupName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}