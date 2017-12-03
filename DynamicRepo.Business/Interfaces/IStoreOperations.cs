using DynamicRepo.Common.Models;
using System.Collections.Generic;

namespace DynamicRepo.Business.Interfaces
{
    public interface IStoreOperations
    {
        bool CreateEntity(CreateEntityModel createEntityModel);

        bool CreateStoreGroup(CreateStoreModel createStoreModel);

        bool RemoveStoreGroup(CreateStoreModel createStoreModel);

        bool StoreEntity(string entityUID, object jsonObject);

        bool StoreEntityCollection(string entityUID, List<object> jsonObjectCollection);

        object GetEntityObject(string entityUID);

        object GetEntityObjectCollection(List<string> entityUID);

        object GetEntityAttribute(string entityUID, List<string> attributeNames);

        object GetEntityAttributeCollection(string entityUID, List<string> attributeNames);

        bool UpsertEntity(string entityUID, object jsonObject);

        bool UpsertEntityCollection(string entityUID, List<object> jsonObjectCollection);

        bool DeleteEntity(string entityUID);

        bool DeleteEntityCollection(List<string> entityUID);
    }
}