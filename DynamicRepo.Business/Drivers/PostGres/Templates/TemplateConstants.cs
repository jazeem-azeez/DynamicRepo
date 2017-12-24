namespace DynamicRepo.Business.Drivers.PostGres.Templates
{
    public static class TemplateConstants
    {
        public static string Keys_CreateDataBaseScript
        {
            get
            {
                return "CREATE DATABASE \"{{databaseName}}\""+@"
                            WITH
                            OWNER = {{userName}}
                            ENCODING = 'UTF8'
                            CONNECTION LIMIT = {{connectionLimit}};";
            }
        }

        public static string Keys_CreateTableScript
        {
            get
            {
                return @"CREATE TABLE
                            {{tableName}}
                            (
                            {{columns}}
                            ) {{partioning}}
                            WITH( OIDS = {{OIDS}} );";
            }
        }

        public static string Keys_DeleteScript
        {
            get
            {
                return @"SELECT {{feilds}} FROM {{tableName}} {{filter}} {{groupBy}};";
            }
        }

        public static string Keys_InsertScript
        {
            get
            {
                return @"INSERT INTO {{tableName}} ({{columnsList}}) VALUES({{valuesList}}); ";
            }
        }

        public static string Keys_SelectScript
        {
            get
            {
                return @"SELECT {{feilds}} FROM {{tableName}} {{filter}} {{groupBy}};";
            }
        }

        public static string Keys_UpdateScript
        {
            get
            {
                return @"UPDATE {{tableName}} SET {{setValueList}} {{filter}} ";
            }
        }
    }
}