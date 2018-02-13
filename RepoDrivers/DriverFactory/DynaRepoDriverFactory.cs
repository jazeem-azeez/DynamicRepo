using RepoDrivers.Driver;
using RepoDrivers.Driver.PostGresDriver;
using System;

namespace RepoDrivers.DriverFactory
{
    public class DynaRepoDriverFactory : IDynaRepoDriverFactory
    {
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
                case StoreMechanisms.PostGresSql: return (IDynaRepoDriver<IStoreMechanismDescriptor>)new PostGresDynaRepoDriver();
            }
            throw new ArgumentException("unknown Mechanism");
        }
    }
}