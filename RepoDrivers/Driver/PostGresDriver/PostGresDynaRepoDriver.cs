using System;
using System.Collections.Generic;
using System.Text;
using RepoDrivers.Driver.PostGres.Entity;
using RepoDrivers.DriverFactory;

namespace RepoDrivers.Driver.PostGresDriver
{
    public class PostGresDynaRepoDriver : IDynaRepoDriver<PostGresMechanismDescriptor>
    {
        public IEntityHandler GetEntityHandler(PostGresMechanismDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public IMechanismHandler GetMechanismHandler(PostGresMechanismDescriptor descriptor)
        {
            throw new NotImplementedException();
        }

        public IStoreHandler GetStoreHandler(PostGresMechanismDescriptor descriptor)
        {
            throw new NotImplementedException();
        }
    }
}
