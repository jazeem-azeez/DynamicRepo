using DynamicRepo.Business.Drivers.PostGres.Templates;
using DynamicRepo.Business.Parsers;
using DynamicRepo.Contracts.Business;
using DynamicRepo.Contracts.Data;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeroConfigServiceSettings;

namespace DynamicRepo.Business.Drivers.PostGres
{
    public class PostGresDriver : IStoreDriverOperations
    {
        private readonly IConfigurationSettings _settings;

        private ISqlQueryRunner<NpgsqlConnection, NpgsqlCommand> _sqlQueryRunner;

        public PostGresDriver(ISqlQueryRunner<NpgsqlConnection, NpgsqlCommand> sqlQueryRunner, IConfigurationSettings settings)
        {
            this._sqlQueryRunner = sqlQueryRunner;
            this._settings = settings;
        }

        public Task<bool> CreateDataStore(JObject storeCreatejObject, IStoreConnection connection)
        {
            HandleBarParser handleBarParser;

            //expects tableName & userName values from user
            var createDataBaseScript = TemplateConstants.Keys_CreateDataBaseScript;

            ScanAndLoadVariables(storeCreatejObject, createDataBaseScript);

            string databaseName = storeCreatejObject[nameof(databaseName)].ToString();
            string userName = storeCreatejObject[nameof(userName)].ToString();
            string connectionLimit = storeCreatejObject[nameof(connectionLimit)].ToString();

            handleBarParser = new HandleBarParser(_settings);

            handleBarParser.UpsertLocalVariable(nameof(databaseName), databaseName);
            handleBarParser.UpsertLocalVariable(nameof(userName), userName);
            handleBarParser.UpsertLocalVariable(nameof(connectionLimit), connectionLimit);

            createDataBaseScript = handleBarParser.ProcessInputString(createDataBaseScript);

            return _sqlQueryRunner.RunSQlExecuteNonQueryAsync(createDataBaseScript, connection);
        }

        public Task<bool> CreateEntiyGroup(JObject entityGroupCreationjObject, IStoreConnection connection)
        {
            //expects tableName & userName values from user
            /*
              expected json formmat
             {
             "entityName":"nname",
             "entityType":"table",
             "databaseName":"postgres",
             "columns_properties":
                 [
                 "proerty1":"value1"
                 "proerty2":"value2"
                 "proerty3":"value3"
                 ]
             }
             */

            string databaseName = GetProperty(entityGroupCreationjObject, nameof(databaseName));
            string entityType = GetProperty(entityGroupCreationjObject, nameof(entityType));
            var createEntityCreateScript = GetEntityCreateScript(entityType);

            var temp = ScanAndLoadVariables(entityGroupCreationjObject, createEntityCreateScript);
            switch (entityType)
            {
                case EntityTypes.Table:
                    createEntityCreateScript = CreateTableTransformations(databaseName, createEntityCreateScript, temp);
                    break;

                case EntityTypes.View:
                    throw new NotImplementedException();
            }

            return _sqlQueryRunner.RunSQlExecuteNonQueryAsync(createEntityCreateScript, connection);
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

        public bool StoreEntity(JObject entityCreationjObject, IStoreConnection connection)
        {
            /*
             expected json formmat
            {
            "entityName":"object1",
            "entityType":"table",
            "object1":
                 [
                 "proerty1":"value1"
                 "proerty2":"value2"
                 "proerty3":"value3"
                 ]
            }
            */
            string entityName = entityCreationjObject[nameof(entityName)].ToString();
            string entityType = entityCreationjObject[nameof(entityType)].ToString();
            var storeEntityScript = GetEntityStoreScript(entityType);

            var temp = ScanAndLoadVariables(entityCreationjObject, storeEntityScript);
            switch (entityType)
            {
                case EntityTypes.Table:
                    storeEntityScript = StoreTableTransformations(entityName, storeEntityScript, temp);
                    break;

                case EntityTypes.View:
                    throw new NotImplementedException();
            }

            _sqlQueryRunner.RunSQlExecuteNonQueryAsync(storeEntityScript, connection);
            return true;
        }

        public JObject UpdateEntities(JObject EntitiesFilterExpresion, JObject UpdatePayLoad)
        {
            throw new NotImplementedException();
        }

        private static string GetColumnsDescriptions(Dictionary<string, List<string>> columnsAndConstrains)
        {
            var descriptors = new List<string>();
            foreach (var item in columnsAndConstrains)
            {
                descriptors.Add($" { item.Key} {string.Join(" ", item.Value)}");
            }

            return string.Join(" , ", descriptors);
        }

        private static string GetEntityCreateScript(string entityType)
        {
            switch (entityType)
            {
                case EntityTypes.Table: return TemplateConstants.Keys_CreateTableScript;
                case EntityTypes.View: return TemplateConstants.Keys_CreateViewScript;
                default: return string.Empty;
            }
        }

        private static string GetEntityStoreScript(string entityType)
        {
            switch (entityType)
            {
                case EntityTypes.Table: return TemplateConstants.Keys_StoreTableScript;
                case EntityTypes.View: return TemplateConstants.Keys_CreateViewScript;
                default: return string.Empty;
            }
        }

        private static string GetProperty(JObject entityGroupCreationjObject, string propertyKey)
        {
            return entityGroupCreationjObject[propertyKey]?.ToString();
        }

        private static Dictionary<string, JToken> ScanAndLoadVariables(JObject payLoad, string script)
        {
            var variablesCollection = HandleBarParser.GetHandleBarVariables(script);
            var result = new Dictionary<string, JToken>();
            foreach (var item in variablesCollection)
            {
                if (payLoad.GetValue(item.ToString()) == null)
                {
                    throw new ArgumentNullException(item.ToString());
                }
                result.Add(item.ToString(), payLoad[item.ToString()]);
            }
            return result;
        }

        private string CreateTableTransformations(string databaseName, string createEntityCreateScript, Dictionary<string, JToken> temp)
        {
            string columns_properties;
            var columnsAndConstraints = temp[nameof(columns_properties)].ToObject<Dictionary<String, List<string>>>();
            columns_properties = GetColumnsDescriptions(columnsAndConstraints);

            HandleBarParser handleBarParser;
            handleBarParser = new HandleBarParser(_settings);
            handleBarParser.UpsertLocalVariable(nameof(databaseName), databaseName);
            handleBarParser.UpsertLocalVariable(nameof(columns_properties), columns_properties);

            createEntityCreateScript = handleBarParser.ProcessInputString(createEntityCreateScript);
            return createEntityCreateScript;
        }

        private string StoreTableTransformations(string entityName, string storeEntityCreateScript, Dictionary<string, JToken> temp)
        {
            string object_properties=string.Empty;
            var properties = temp[entityName].ToObject<Dictionary<string,string>>();
            string columns = string.Join(",", properties.Keys.ToArray());

            string values = string.Join(",", properties.Values.ToArray());
            //TODO :types handling

            HandleBarParser handleBarParser;
            handleBarParser = new HandleBarParser(_settings);
            handleBarParser.UpsertLocalVariable(EntityTypes.Table, entityName);
            handleBarParser.UpsertLocalVariable(nameof(columns), columns);
            handleBarParser.UpsertLocalVariable(nameof(values), values);

            storeEntityCreateScript = handleBarParser.ProcessInputString(storeEntityCreateScript);
            return storeEntityCreateScript;
        }

        public Task<bool> CreateEntiyGroup(JObject jObjectCreatePayLoad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateEntiyGroup(JObject jObjectCreatePayLoad, string entityname, string attributeName, IStoreConnection connection)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateEntiyGroup(JObject jObjectCreatePayLoad, string entityname, IStoreConnection connection)
        {
            throw new NotImplementedException();
        }

        public static class EntityTypes
        {
            public const string Table = "table";
            public const string View = "view";
        }
    }
}