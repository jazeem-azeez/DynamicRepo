using Bussines.Mechanism.StoreGroup.Entities;
using Contracts.Mechanism.StoreGroup.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.InjectionBindings.Business
{
    public static class BusinessInjection
    {
        public static void Bind(IServiceCollection service)
        {
            service.AddTransient<IEntitiesCrud, EntitiesCrud>();
        }
    }
}