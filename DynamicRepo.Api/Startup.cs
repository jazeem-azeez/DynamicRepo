using Autofac;
using Autofac.Extensions.DependencyInjection;
using DynamicRepo.Business.Drivers;
using DynamicRepo.Business.Drivers.PostGres;
using DynamicRepo.Business.StoreGroup;
using DynamicRepo.Contracts.Business;
using DynamicRepo.Contracts.Business.Constants;
using DynamicRepo.Contracts.Data;
using DynamicRepo.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using ZeroConfigServiceSettings;

namespace DynamicRepo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            var builder = new ContainerBuilder();

            // read service collection to the custom container
            builder.Populate(services);

            // use and configure the custom container
            builder.RegisterType<StoreGroupBusiness>().As<IStoreGroupBusiness>();
            builder.RegisterType<StoreConnection>().As<IStoreConnection>();
            builder.RegisterType<ConfigurationSettings>().As<IConfigurationSettings>();
            builder.RegisterType<DefaultSettingsStore>().As<ISettingsStore>();
            builder.RegisterType(typeof(PostGresSqlQueryRunner)).As(typeof(ISqlQueryRunner<NpgsqlConnection, NpgsqlCommand>));

            builder.RegisterType<PostGresDriver>()
                .As<IStoreDriverOperations>().Keyed<IStoreDriverOperations>(Mechanisms.PostGres);

            builder.Register<Func<Mechanisms, IStoreDriverOperations>>(c =>
            {
                var componentContext = c.Resolve<IComponentContext>();
                return (roleName) =>
                {
                    var dataService = componentContext.ResolveKeyed<IStoreDriverOperations>(roleName);
                    return dataService;
                };
            });

            // creating the IServiceProvider out of the custom container
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }
    }
}