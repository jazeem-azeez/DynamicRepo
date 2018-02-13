using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicRepo.Contracts.Business
{
    public interface IStoreConnection
    {
        string ConnectionString { get; set; }
        IStoreConnection GetStoreConnection(string storeGroupId=null);
    }
}
