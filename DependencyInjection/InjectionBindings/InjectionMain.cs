using Contracts.InjectionBindings;
using DependencyInjection.InjectionBindings.Business;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.InjectionBindings
{
    public static class InjectionMain 
    {
        public static void Bind(IServiceCollection service)
        {
            BusinessInjection.Bind(service);
        }
    }
}
