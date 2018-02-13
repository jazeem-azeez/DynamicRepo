using Newtonsoft.Json.Linq;
using RepoDrivers.DriverFactory;
using RepoDrivers.Sql.PostGres;
using RepoDrivers.Sql.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoDrivers.Driver.PostGres.Entity
{
    public class PostGresEntityCrudHandler : IEntityHandler 
    {
        private readonly ISqlEntityScriptGenerator _scriptGenerator;
        private readonly ISqlCommandRunner<IStoreMechanismDescriptor> _commandRunner;

        public PostGresEntityCrudHandler(ISqlEntityScriptGenerator scriptGenerator,ISqlCommandRunner<IStoreMechanismDescriptor> commandRunner)
        {
            this._scriptGenerator = scriptGenerator;
            this._commandRunner = commandRunner;

        }
        public JObject Delete(IStoreMechanismDescriptor mechanism, string entityName, string filter)
        {
            string command = _scriptGenerator.Delete(entityName, filter);
            var response  = _commandRunner.RunScalarCommand(command,mechanism);
            return response ;
        }

        public JObject Get(IStoreMechanismDescriptor mechanism, string entityName) => Get(mechanism, entityName, "", 0, 1000);

        public JObject Get(IStoreMechanismDescriptor mechanism, string entityName, string filter, int offset, int limit)
        {
            string command = _scriptGenerator.Retrive(entityName, filter,offset,limit);
            var response = _commandRunner.RunVectorCommand(command,mechanism);
            return response ;
        }

        public JObject Post(IStoreMechanismDescriptor mechanism, string entityName, JObject value)
        {
            string command = _scriptGenerator.CreateAndInsert(value,entityName);
            var response  = _commandRunner.RunScalarCommand(command,mechanism);
            return response ;
        }

        public JObject Put(IStoreMechanismDescriptor mechanism, string entityName, string filter, JObject value)
        {
            string command = _scriptGenerator.Update(entityName, filter,value);
            var response  = _commandRunner.RunScalarCommand(command,mechanism);
            return response ;
        }
    }
}
