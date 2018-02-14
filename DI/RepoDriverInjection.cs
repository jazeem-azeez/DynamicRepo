using Microsoft.Extensions.DependencyInjection;
using RepoDrivers.Driver;
using RepoDrivers.Driver.PostGres;
using RepoDrivers.Driver.PostGres.Entity;
using RepoDrivers.Driver.PostGresDriver;
using RepoDrivers.DriverFactory;

namespace DI
{
    public static class RepoDriverInjection
    {
        public static void Bind(IServiceCollection service)
        {
            service.AddTransient<IDynaRepoDriver<PostGresMechanismDescriptor>, PostGresDynaRepoDriver>();
            service.AddTransient<IEntityHandler<PostGresMechanismDescriptor>, PostGresEntityHandler>();
            service.AddTransient<ISqlCommandRunner<PostGresMechanismDescriptor>, PgSqlCommandRunner>();
        }
    }
}