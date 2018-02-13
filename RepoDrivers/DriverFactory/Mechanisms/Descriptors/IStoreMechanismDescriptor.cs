namespace RepoDrivers.DriverFactory
{
    public interface IStoreMechanismDescriptor
    {
        string ConnectionString { get; set; }
        string EndPoint { get; set; }
        StoreMechanisms Mechanism { get; }
        string StoreGroupName { get; set; }
        string User { get; set; }
    }
}