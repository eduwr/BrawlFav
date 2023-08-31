using BrawlFav.Models;
using BrawlFav.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

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

            Assert.AreEqual(first?.Id, firstCreatedBrawler.Id);
            Assert.AreEqual(second?.Id, secondCreatedBrawler.Id);

            var nullBrawl = BrawlerService.GetBrawler(3);
            Assert.IsNull(nullBrawl);
        }

        [TestMethod]
        public void Update_ExistingBrawler()
        {
            string name = "SHELLY";
            var brawler = BrawlerService.Create(new DTOs.CreateBrawlerDTO { Name = name });


            string newName = "16-BIT";
            var updated = BrawlerService.Update(new DTOs.UpdateBrawlerDTO { Id = brawler.Id, Name = newName });

            Assert.AreEqual(updated, brawler.Id);

            brawler = BrawlerService.GetBrawler(updated);

            Assert.AreEqual(brawler?.Name, newName);

        }

        [TestMethod]
        public void Update_NonExistingBrawler()
        {
            string newName = "16-BIT";
            var updated = BrawlerService.Update(new DTOs.UpdateBrawlerDTO { Id = 2, Name = newName });

            Assert.AreEqual(updated, -1);
        }


        [TestMethod]
        public void Delete_ExistingBrawler()
        {
            string name = "SHELLY";
            var brawler = BrawlerService.Create(new DTOs.CreateBrawlerDTO { Name = name });

            var updated = BrawlerService.Delete(brawler.Id);

            Assert.AreEqual(updated, 1);

            var afterUpdateBrawler = BrawlerService.GetBrawler(brawler.Id);

            Assert.IsNull(afterUpdateBrawler);

        }


        [TestMethod]
        public void Delete_NonExistingBrawler()
        {
            var updated = BrawlerService.Delete(50);

            Assert.AreEqual(updated, -1);

        }


    }
}