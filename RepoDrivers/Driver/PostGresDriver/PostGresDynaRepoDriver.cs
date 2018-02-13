using RepoDrivers.Driver.PostGres.Entity;
using RepoDrivers.DriverFactory;
using RepoDrivers.Sql.PostGres;
using System;

namespace RepoDrivers.Driver.PostGresDriver
{
    public class PostGresDynaRepoDriver : IDynaRepoDriver<PostGresMechanismDescriptor>
    {
        public IActionObserver observer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PostGresMechanismDescriptor Descriptor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEntityHandler GetEntityHandler()
        {
            return new PostGresEntityHandler(new PostGresEntityScriptGenerator(), (ISqlCommandRunner<IStoreMechanismDescriptor>)new PostGres.PgSqlCommandRunner(),new PostGresMechanismDescriptor());
        }

        public IMechanismHandler GetMechanismHandler()
        {
            throw new NotImplementedException();
        }

        public IStoreHandler GetStoreHandler()
        {
            throw new NotImplementedException();
        }

        public void SetDescriptor(PostGresMechanismDescriptor value)
        {
            throw new NotImplementedException();
        }
    }
}