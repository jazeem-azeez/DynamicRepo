using Newtonsoft.Json.Linq;
using RepoDrivers.DriverFactory;

namespace RepoDrivers.Driver.PostGres.Entity
{
    public interface ISqlCommandRunner<T> where T : class, IStoreMechanismDescriptor
    {
        JToken RunScalarCommand(string command, T mechanism);

        JToken RunVectorCommand(string command, T mechanism);
    }
}