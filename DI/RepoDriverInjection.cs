using Contracts.SharedModels;
using Microsoft.Extensions.DependencyInjection;
using RepoDrivers;
using RepoDrivers.Driver;
using RepoDrivers.Driver.PostGres;
using RepoDrivers.Driver.PostGres.Entity;
using RepoDrivers.Driver.PostGresDriver;
using RepoDrivers.DriverFactory;
using RepoDrivers.DriverFactory.Connection;
using RepoDrivers.Sql.PostGres;
using RepoDrivers.Sql.Shared;

namespace DI
{
    public static class RepoDriverInjection
    {
        public static void Bind(IServiceCollection service)
        {
            //RepoDrivers.DriverFactory.IDynaRepoDriverFactory
            service.AddTransient<IDynaRepoDriverFactory, DynaRepoDriverFactory>();
            service.AddTransient<IDynaRepoDriver<PostGresMechanismDescriptor>, PostGresDynaRepoDriver>();
            service.AddTransient<IEntityHandler<PostGresMechanismDescriptor>, PostGresEntityHandler>();
            service.AddTransient<ISqlCommandRunner<PostGresMechanismDescriptor>, PgSqlCommandRunner>();
            service.AddTransient<ISqlEntityScriptGenerator<PostGresMechanismDescriptor>, PostGresEntityScriptGenerator>();
            service.AddSingleton<PostGresMechanismDescriptor, PostGresMechanismDescriptor>();
            service.AddTransient<IConnectionInfoManager, ConnectionInfoManager>();
        }
    }
}