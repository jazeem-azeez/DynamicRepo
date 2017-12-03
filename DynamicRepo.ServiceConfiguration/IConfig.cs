namespace DynamicRepo.ServiceConfiguration
{
    public interface IConfig
    {
        string PGConnectionString { get; set; }
    }
}