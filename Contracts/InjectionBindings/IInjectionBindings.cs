using Microsoft.Extensions.DependencyInjection;

namespace Contracts.InjectionBindings
{
    public interface IInjectionBindings
    {
        IServiceCollection Bind(IServiceCollection service);
    }
}