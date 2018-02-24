using Contracts.RepoDrivers.Mechanism;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.SharedModels
{
    public class ConnectionInfo
    {
        public string ConnectionKey { get; set; }
        public object ConnectionInfoObject { get; set; }
        public StoreMechanisms StoreMechanism { get; set; }
    }
}
