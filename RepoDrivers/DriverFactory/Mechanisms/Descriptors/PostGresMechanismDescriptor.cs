namespace RepoDrivers.DriverFactory
{
    public class PostGresMechanismDescriptor : IStoreMechanismDescriptor
    {
        public StoreMechanisms Mechanism { get{ return StoreMechanisms.PostGresSql; } }
        public string StoreGroupName { get; set; }
        public string ConnectionString { get; set; }
        public string EndPoint { get; set; }
        public string User { get; set; }
    }
}