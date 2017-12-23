using Microsoft.Extensions.Configuration;

namespace DynamicRepo.ServiceConfiguration
{
    public class ZeroConfig : IZeroConfig
    {
        private readonly IConfiguration _config;
        private readonly string _section;

        public ZeroConfig(IConfiguration configuration)
        {
            this._config = configuration;
            this._section = "Appsettings:";
        }
        public string PGConnectionString
        {
            get => throw new System.NotImplementedException();

            set => throw new System.NotImplementedException();

        }
        public string[] SupportedMechanisms { get => _config.GetSection(_section).GetSection("mechanism").Value.Split(','); }
    }
}