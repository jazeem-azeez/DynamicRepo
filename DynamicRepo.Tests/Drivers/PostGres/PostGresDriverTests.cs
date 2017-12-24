//using DynamicRepo.Business.Drivers.PostGres;
//using DynamicRepo.Contracts.Data;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Newtonsoft.Json.Linq;
//using Npgsql;

//namespace DynamicRepo.Tests.Drivers.PostGres
//{
//    [TestClass]
//    public class PostGresDriverTests
//    {
//        private MockRepository mockRepository;

//        private Mock<ISqlQueryRunner<NpgsqlConnection, NpgsqlCommand>> mockSqlQueryRunner;

//        [TestInitialize]
//        public void TestInitialize()
//        {
//            this.mockRepository = new MockRepository(MockBehavior.Strict);

//            this.mockSqlQueryRunner = this.mockRepository.Create<ISqlQueryRunner<NpgsqlConnection, NpgsqlCommand>>();
//        }

//        [TestCleanup]
//        public void TestCleanup()
//        {
//            this.mockRepository.VerifyAll();
//        }

//        [TestMethod]
//        public void TestMethod1()
//        {
//            // Arrange


//            // Act
//            PostGresDriver postGresDriver = this.CreatePostGresDriver();

//            postGresDriver.CreateDataStore(new JObject(new { tableName = "tableName", userName = "userName", connectionLimit = "-1" }));
//            // Assert

//        }

//        private PostGresDriver CreatePostGresDriver()
//        {
//            return new PostGresDriver(
//                this.mockSqlQueryRunner.Object);
//        }
//    }
//}
