using System;
using System.Collections.Generic;

namespace ZeroConfigServiceSettings
{
    public class DefaultSettingsStore : ISettingsStore

    {
        private Dictionary<string, object> dictionary;

        public DefaultSettingsStore()
        {
            dictionary = new Dictionary<string, object>();
        }

        public T GetValueOrDefault<T>(string name)
            where T : class
        {
            return dictionary.ContainsKey(name) ? dictionary[name] as T : default(T);
        }

        public T SetValueOrDefault<T>(string name, T Value)
            where T : class

        {
            throw new NotImplementedException();
        }
    }
}