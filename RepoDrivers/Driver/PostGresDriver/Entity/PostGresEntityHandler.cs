using Newtonsoft.Json.Linq;
using RepoDrivers.DriverFactory;
using RepoDrivers.Sql.PostGres;
using RepoDrivers.Sql.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoDrivers.Driver.PostGres.Entity
{
    public class PostGresEntityHandler : IEntityHandler 
    {
        private readonly ISqlEntityScriptGenerator _scriptGenerator;
        private readonly IStoreMechanismDescriptor mechanism;
        private readonly ISqlCommandRunner<IStoreMechanismDescriptor> _commandRunner;

        public PostGresEntityHandler(ISqlEntityScriptGenerator scriptGenerator,ISqlCommandRunner<IStoreMechanismDescriptor> commandRunner, IStoreMechanismDescriptor mechanism)
        {
            this._scriptGenerator = scriptGenerator;
            this.mechanism=mechanism;
            this._commandRunner = commandRunner;

        }

        public IStoreMechanismDescriptor StoreMechanismDescriptor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public JObject Delete( string entityName, string filter)
        {
            string command = _scriptGenerator.Delete(entityName, filter);
            var response  = _commandRunner.RunScalarCommand(command,mechanism);
            return response ;
        }

        public JObject Get( string entityName) => Get(entityName, "", 0, 1000);

        public JObject Get( string entityName, string filter, int offset, int limit)
        {
            string command = _scriptGenerator.Retrive(entityName, filter,offset,limit);
            var response = _commandRunner.RunVectorCommand(command,mechanism);
            return response ;
        }

        public JObject Post( string entityName, JObject value)
        {
            string command = _scriptGenerator.CreateAndInsert(value,entityName);
            var response  = _commandRunner.RunScalarCommand(command,mechanism);
            return response ;
        }

        public JObject Put( string entityName, string filter, JObject value)
        {
            string command = _scriptGenerator.Update(entityName, filter,value);
            var response  = _commandRunner.RunScalarCommand(command,mechanism);
            return response ;
        }
    }
}
