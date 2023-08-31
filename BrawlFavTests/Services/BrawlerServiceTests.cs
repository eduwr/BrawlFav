using BrawlFav.Models;
using BrawlFav.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrawlFav.Services.Tests

{
    [TestClass]
    public class BrawlerServiceTests
    {
        [TestMethod]
        public void Create_AddsBrawlerToList()
        {

            var createdBrawler = BrawlerService.Create();

            var brawlers = BrawlerService.GetAll();

            Assert.AreEqual(1, brawlers.Count);
            Assert.AreEqual(createdBrawler, brawlers.First());

        }

        [TestMethod]
        public void Create_ReturnsCreatedBrawler()
        {
            var expectedId = 1;
            var expectedName = "test";

            var createdBrawler = BrawlerService.Create();

            Assert.AreEqual(expectedId, createdBrawler.Id);
            Assert.AreEqual(expectedName, createdBrawler.Name);
            Assert.AreEqual(0, createdBrawler.StarPowers.Length);
            Assert.AreEqual(0, createdBrawler.Gadgets.Length);
        }
    }
}