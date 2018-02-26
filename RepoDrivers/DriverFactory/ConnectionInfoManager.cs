using Contracts.RepoDrivers.Mechanism;
using Contracts.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoDrivers.DriverFactory.Connection
{
    public class ConnectionInfoManager : IConnectionInfoManager
    {
        private static Dictionary<string, ConnectionInfo> _dictionary = new Dictionary<string, ConnectionInfo>();
        private static object _sharedSimpleLock = new object();

         static  ConnectionInfoManager()
        {
            if (_dictionary.Count == 0)
            {
                PostGresMechanismDescriptor pgDs = new PostGresMechanismDescriptor();

                pgDs.User = "postgres";
                pgDs.Password = "root";
                pgDs.EndPoint= "127.0.0.1";
                pgDs.StoreGroupName= "DataRepo";
                pgDs.ConnectionString = $"Server={pgDs.EndPoint};Port=5432;Database={pgDs.StoreGroupName};Userid={pgDs.User};Password = {pgDs.Password}; ";
                new ConnectionInfoManager().SetConnectionInfo(pgDs.Mechanism.ToString(), pgDs.StoreGroupName, new ConnectionInfo() { ConnectionInfoObject = pgDs, ConnectionKey = GetKey(pgDs.Mechanism.ToString(), pgDs.StoreGroupName) });
            }
        }

        public ConnectionInfo GetConnectionInfo(string key)
        {
            return (_dictionary.ContainsKey(key)) ? _dictionary[key] : null;
        }
        public ConnectionInfo GetConnectionInfo(string mechanims, string storeGroup) => GetConnectionInfo(GetKey(mechanims, storeGroup));
        public bool SetConnectionInfo(string key, ConnectionInfo connectionInfo)
        {
            lock (_sharedSimpleLock)
            {
                if (_dictionary.ContainsKey(key) == false)
                    _dictionary.Add(key, connectionInfo);
                else
                    _dictionary[key] = connectionInfo;
                return true;
            }
        }
        public bool SetConnectionInfo(string mechanims, string storeGroup, ConnectionInfo connectionInfo) => SetConnectionInfo(GetKey(mechanims, storeGroup), connectionInfo);

        private static string GetKey(string mechanims, string storeGroup)
        {
            return $"<{mechanims}/>:<{storeGroup}/>";
        }
    }
}
