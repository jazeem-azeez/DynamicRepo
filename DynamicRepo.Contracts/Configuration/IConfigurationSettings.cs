namespace ZeroConfigServiceSettings
{
    public interface IConfigurationSettings
    {
        string this[string Name] { get; }
    }
}