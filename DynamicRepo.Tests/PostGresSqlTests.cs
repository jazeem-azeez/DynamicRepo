using DynamicRepo.Business;
using DynamicRepo.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicRepo.Tests.Business
{
    [TestClass]
    public class PostGresSqlTests
    {
        [TestMethod]
        public void CreateTableScriptGeneratorTests()
        {
            PostGresSql p1 = new PostGresSql();
            CreateEntityModel createEntityModel = new CreateEntityModel()
            {
                AttributesCollection = new System.Collections.Generic.List<EntityAttribute>()
                {
                    { new EntityAttribute (){ AttributeName="Id",Properties=new string[]{ "text" } } },
                    {new EntityAttribute (){ AttributeName="value",Properties=new string[]{ "text" } } }
                },
                EntityName = "TestTable",
                EntityUID = "none",
                StoreGroupId = "database",
                Constraints = new string[] { "\"TestTable_pkey\" PRIMARY KEY (id)" }
            };
            var testOutStr = p1.CreateTableScriptGenerator(createEntityModel);
        }
    }
}