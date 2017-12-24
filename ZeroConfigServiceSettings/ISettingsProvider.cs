namespace ZeroConfigServiceSettings
{
    public interface ISettingsStore
    {

        T GetValueOrDefault<T>(string name)
            where T : class;
        T SetValueOrDefault<T>(string name, T Value)
            where T : class;

    }
}