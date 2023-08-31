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
            string firstName = "SHELLY";
            var createdBrawler = BrawlerService.Create(new DTOs.CreateBrawlerDTO { Name = firstName });

            var brawlers = BrawlerService.GetAll();

            Assert.AreEqual(1, brawlers.Count);
            Assert.AreEqual(createdBrawler, brawlers.First());
            Assert.AreEqual(brawlers[0].Name, firstName);
            Assert.AreEqual(0, createdBrawler.StarPowers.Length);
            Assert.AreEqual(0, createdBrawler.Gadgets.Length);

            string secondName = "SQUEAK";
            createdBrawler = BrawlerService.Create(new DTOs.CreateBrawlerDTO { Name = secondName });
            brawlers = BrawlerService.GetAll();

            Assert.AreEqual(2, brawlers.Count);
            Assert.AreEqual(createdBrawler, brawlers[1]);
            Assert.AreEqual(brawlers[1].Name, secondName);
        }
        
         
        [TestMethod]
        public void GetBrowler_ById()
        {
            string firstName = "SHELLY";
            var firstCreatedBrawler = BrawlerService.Create(new DTOs.CreateBrawlerDTO { Name = firstName });
            string secondName = "SQUEAK";
            var secondCreatedBrawler = BrawlerService.Create(new DTOs.CreateBrawlerDTO { Name = secondName });
 
            var first = BrawlerService.GetBrawler(firstCreatedBrawler.Id);
            var second = BrawlerService.GetBrawler(secondCreatedBrawler.Id);

            Assert.AreEqual(first.Id, firstCreatedBrawler.Id);
            Assert.AreEqual(second.Id, secondCreatedBrawler.Id);
        }

    }
}