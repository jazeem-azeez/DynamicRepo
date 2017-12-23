using DynamicRepo.Business;
using DynamicRepo.Business.storegroup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DynamicRepo.Tests
{
    [TestClass]
    public class StoreGroupBusinessTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange


            // Act
            StoreGroupBusiness storeGroupBusiness = this.CreateStoreGroupBusiness();


            // Assert

        }

        private StoreGroupBusiness CreateStoreGroupBusiness()
        {
            return new StoreGroupBusiness(null);
        }
    }
}
