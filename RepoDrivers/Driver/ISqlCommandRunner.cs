using Newtonsoft.Json.Linq;
using RepoDrivers.DriverFactory;

namespace RepoDrivers.Driver.PostGres.Entity
{
    public interface ISqlCommandRunner<T> where T : class, IStoreMechanismDescriptor
    {
        JObject RunScalarCommand(string command, T mechanism);

        JObject RunVectorCommand(string command, T mechanism);
    }
}