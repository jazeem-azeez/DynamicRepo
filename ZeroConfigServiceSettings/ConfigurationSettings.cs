using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroConfigServiceSettings
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        private readonly ISettingsStore _settingsProvider;

        public ConfigurationSettings(ISettingsStore settingsProvider)
        {
            this._settingsProvider = settingsProvider;
        }
        public string this[string Name]
        {
            get { return _settingsProvider.GetValueOrDefault<string>(Name); }
            set { _settingsProvider.SetValueOrDefault<string>(Name, value); }
        }
    }
}
