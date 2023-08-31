using BrawlFav.Models;
using BrawlFav.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace BrawlFav.Services.Tests

{
    [TestClass]
    public class BrawlerServiceTests
    {
        private readonly BrawlerService _brawlerService;


        public BrawlerServiceTests()
        {
            _brawlerService = new BrawlerService();
        }


        [TestMethod]
        public void Create_AddsBrawlerToList()
        {
            string firstName = "SHELLY";
            var createdBrawler = _brawlerService.Create(new DTOs.CreateBrawlerDTO { Name = firstName });

            var brawlers = _brawlerService.GetAll();

            Assert.AreEqual(1, brawlers.Count);
            Assert.AreEqual(createdBrawler, brawlers.First());
            Assert.AreEqual(brawlers[0].Name, firstName);
            Assert.AreEqual(0, createdBrawler.StarPowers.Length);
            Assert.AreEqual(0, createdBrawler.Gadgets.Length);

            string secondName = "SQUEAK";
            createdBrawler = _brawlerService.Create(new DTOs.CreateBrawlerDTO { Name = secondName });
            brawlers = _brawlerService.GetAll();

            Assert.AreEqual(2, brawlers.Count);
            Assert.AreEqual(createdBrawler, brawlers[1]);
            Assert.AreEqual(brawlers[1].Name, secondName);
        }


        [TestMethod]
        public void GetBrowler_ById()
        {
            string firstName = "SHELLY";
            var firstCreatedBrawler = _brawlerService.Create(new DTOs.CreateBrawlerDTO { Name = firstName });
            string secondName = "SQUEAK";
            var secondCreatedBrawler = _brawlerService.Create(new DTOs.CreateBrawlerDTO { Name = secondName });

            var first = _brawlerService.GetBrawler(firstCreatedBrawler.Id);
            var second = _brawlerService.GetBrawler(secondCreatedBrawler.Id);

            Assert.AreEqual(first?.Id, firstCreatedBrawler.Id);
            Assert.AreEqual(second?.Id, secondCreatedBrawler.Id);

            var nullBrawl = _brawlerService.GetBrawler(3);
            Assert.IsNull(nullBrawl);
        }

        [TestMethod]
        public void Update_ExistingBrawler()
        {
            string name = "SHELLY";
            var brawler = _brawlerService.Create(new DTOs.CreateBrawlerDTO { Name = name });


            string newName = "16-BIT";
            var updated = _brawlerService.Update(new DTOs.UpdateBrawlerDTO { Id = brawler.Id, Name = newName });

            Assert.AreEqual(updated, brawler.Id);

            brawler = _brawlerService.GetBrawler(updated);

            Assert.AreEqual(brawler?.Name, newName);

        }

        [TestMethod]
        public void Update_NonExistingBrawler()
        {
            string newName = "16-BIT";
            var updated = _brawlerService.Update(new DTOs.UpdateBrawlerDTO { Id = 2, Name = newName });

            Assert.AreEqual(updated, -1);
        }


        [TestMethod]
        public void Delete_ExistingBrawler()
        {
            string name = "SHELLY";
            var brawler = _brawlerService.Create(new DTOs.CreateBrawlerDTO { Name = name });

            var updated = _brawlerService.Delete(brawler.Id);

            Assert.AreEqual(updated, 1);

            var afterUpdateBrawler = _brawlerService.GetBrawler(brawler.Id);

            Assert.IsNull(afterUpdateBrawler);

        }


        [TestMethod]
        public void Delete_NonExistingBrawler()
        {
            var updated = _brawlerService.Delete(50);

            Assert.AreEqual(updated, -1);

        }


    }
}