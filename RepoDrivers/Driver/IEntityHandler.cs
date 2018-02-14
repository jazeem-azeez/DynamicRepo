﻿using Newtonsoft.Json.Linq;
using RepoDrivers.DriverFactory;

namespace RepoDrivers.Driver.PostGres.Entity
{
    public interface IEntityHandler<T> where T : class, IStoreMechanismDescriptor
    {
        T Mechanism { get; set; }

        JObject Delete(string entityName, string filter);

        JObject Get(string entityName);

        JObject Get(string entityName, string filter, int offset, int limit);

        JObject Post(string entityName, JObject value);

        JObject Put(string entityName, string filter, JObject value);
    }
}