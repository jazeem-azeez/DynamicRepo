using DynamicRepo.Business.Drivers.PostGres.Templates;
using DynamicRepo.Business.Parsers;
using DynamicRepo.Contracts.Business;
using DynamicRepo.Contracts.Data;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Threading.Tasks;
using ZeroConfigServiceSettings;

namespace DynamicRepo.Business.Drivers.PostGres
{
    public class PostGresDriver : IStoreDriverOperations
    {
        private ISqlQueryRunner<NpgsqlConnection, NpgsqlCommand> _sqlQueryRunner;
        private readonly IConfigurationSettings _settings;

        public PostGresDriver(ISqlQueryRunner<NpgsqlConnection, NpgsqlCommand> sqlQueryRunner, IConfigurationSettings settings)
        {
            this._sqlQueryRunner = sqlQueryRunner;
            this._settings = settings;
        }

        public Task<bool> CreateDataStore(JObject storeCreatejObject)
        {
        HandleBarParser handleBarParser;

        //expects tableName & userName values from user
        var createDataBaseScript = TemplateConstants.Keys_CreateDataBaseScript;
            ValidateForVariables(storeCreatejObject, createDataBaseScript);
            handleBarParser = new HandleBarParser(_settings, new System.Collections.Generic.Dictionary<string, string>()
            {
                {"{{databaseName}}",$"tempTest{DateTime.Now.Millisecond}" },
                {"{{userName}}","postgres" },
                { "{{connectionLimit}}","-1" }

            });
            createDataBaseScript =  handleBarParser.ProcessInputString(createDataBaseScript);
            _sqlQueryRunner.RunSQlExecuteNonQuery(createDataBaseScript);
            return Task.FromResult(false);
        }

        private static bool ValidateForVariables(JObject storeCreatejObject, string CreateDataBaseScript)
        {
            var variablesCollection = HandleBarParser.GetHandleBarVariables(CreateDataBaseScript);
            foreach (var item in variablesCollection)
            {
                if (storeCreatejObject.GetValue(item.ToString()) == null)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CreateEntiyGroup(JObject entityGroupCreationjObject)
        {
            throw new NotImplementedException();
        }

        public JObject DeleteEntities(JObject EntitiesFilterExpresion)
        {
            throw new NotImplementedException();
        }

        public bool EventSubscriptionRegistration(JObject EventFilterExpression)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStore(string StoreId)
        {
            throw new NotImplementedException();
        }

        public JObject RetriveEntities(JObject EntitiesFilterExpresion)
        {
            throw new NotImplementedException();
        }

        public bool StoreEntity(JObject entityGroupCreationjObject)
        {
            throw new NotImplementedException();
        }

        public JObject UpdateEntities(JObject EntitiesFilterExpresion, JObject UpdatePayLoad)
        {
            throw new NotImplementedException();
        }
    }
}