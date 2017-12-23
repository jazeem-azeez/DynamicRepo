namespace DynamicRepo.ServiceConfiguration
{
    public interface IZeroConfig
    {
        string PGConnectionString { get; set; }
        string [] SupportedMechanisms { get; }
    }
}