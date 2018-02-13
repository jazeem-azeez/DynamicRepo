In short, this is a Rest Api Based Wrapper for Data Store With Event Messaging and triggers Sql Query Capability for Sql DataStores DataStores Supported are (Both Sql & No Sql) Postgres Sql Redis
Note : new .Net Core Version is under development Under directory DynaRepo
### this project is still not ready for public where as contributers and comments/ advices are invited 

# Api Routes
### api/v1/mechanism/[name]
### api/v1/mechanism/{mechanism}/storegroups/{storegroupName}
[Post]
will be used for store level queries and manipulation
Eg; Database Creation
### api/v1/[mechanism]/[storegroupName]/[entityName]
[Post]
will be used for entity collection level queries
and manipulation
custom entity creation 
### api/v1/[mechanism]/[storegroupName]/[entityName]/[id]/
operations for a particular entity 
eg : post operation will create an entity with provided json under given entity name & id

### api/v1/[mechanism]/[storegroupName]/[entityName]/[id]/[attribute]
 eg : Put  will let you perform update operation on attirbute

 Currently supported mechanisms
### mechanism={postgressql,redis}

### storegroup={default,databasename}
### entityName={account,tablename}

