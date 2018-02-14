using Newtonsoft.Json.Linq;
using RepoDrivers.DriverFactory;
using RepoDrivers.Sql.Shared;

namespace RepoDrivers.Driver.PostGres.Entity
{
    public class PostGresEntityHandler : IEntityHandler<PostGresMechanismDescriptor>
    {
        public PostGresMechanismDescriptor _mechanism;
        private readonly ISqlCommandRunner<PostGresMechanismDescriptor> _commandRunner;
        private readonly ISqlEntityScriptGenerator _scriptGenerator;

        public PostGresEntityHandler(ISqlEntityScriptGenerator scriptGenerator, ISqlCommandRunner<PostGresMechanismDescriptor> commandRunner, PostGresMechanismDescriptor mechanism)
        {
            this._scriptGenerator = scriptGenerator;
            this._mechanism = mechanism;
            this._commandRunner = commandRunner;
        }

        public PostGresMechanismDescriptor Mechanism { get => _mechanism; set => _mechanism = value; }

        public JObject Delete(string entityName, string filter)
        {
            string command = _scriptGenerator.Delete(entityName, filter);
            var response = _commandRunner.RunScalarCommand(command, _mechanism);
            return response;
        }

        public JObject Get(string entityName) => Get(entityName, "", 0, 1000);

        public JObject Get(string entityName, string filter, int offset, int limit)
        {
            string command = _scriptGenerator.Retrive(entityName, filter, offset, limit);
            var response = _commandRunner.RunVectorCommand(command, _mechanism);
            return response;
        }

        public JObject Post(string entityName, JObject value)
        {
            string command = _scriptGenerator.CreateAndInsert(value, entityName);
            var response = _commandRunner.RunScalarCommand(command, _mechanism);
            return response;
        }

        public JObject Put(string entityName, string filter, JObject value)
        {
            string command = _scriptGenerator.Update(entityName, filter, value);
            var response = _commandRunner.RunScalarCommand(command, _mechanism);
            return response;
        }
    }
}