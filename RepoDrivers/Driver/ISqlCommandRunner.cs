using Newtonsoft.Json.Linq;
using RepoDrivers.DriverFactory;

namespace RepoDrivers.Driver.PostGres.Entity
{
    public interface ISqlCommandRunner<T>
    {
        JObject RunScalarCommand(string command, T mechanism);
        JObject RunVectorCommand(string command, T mechanism);
    }
}