using Contracts.InjectionBindings;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public class InjectionBindings : IInjectionBindings
    {
        public IServiceCollection Bind(IServiceCollection service)
        {
            BusinessInjection.Bind(service);
            RepoDriverInjection.Bind(service);
            return service;
        }
    }
}