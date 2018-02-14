namespace RepoDrivers.DriverFactory
{
    public class PostGresMechanismDescriptor : IStoreMechanismDescriptor
    {
        public string ConnectionString { get; set; }
        public string EndPoint { get; set; }
        public StoreMechanisms Mechanism { get { return StoreMechanisms.PostGresSql; } }
        public string StoreGroupName { get; set; }
        public string User { get; set; }
    }
}