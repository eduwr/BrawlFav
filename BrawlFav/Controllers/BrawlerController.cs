using BrawlFav.DTOs;
using BrawlFav.Models;
using BrawlFav.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrawlFav.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrawlerController : ControllerBase
    {

        private readonly IBrawlerService _brawlerService;


        public BrawlerController(IBrawlerService brawlerService)
        {
            _brawlerService = brawlerService;
        }

        // GET: BrawlerController
        [HttpGet(Name = "GetBrawlers")]
        public ActionResult<List<Brawler>> Index()
        {
            return Ok(_brawlerService.GetAll());
        }

        // GET: BrawlerController/5
        [HttpGet(Name = "GetBrawler")]
        public ActionResult<Brawler> Details([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID");
            }

            var brawler = _brawlerService.GetBrawler(id);
            if (brawler == null)
            {
                return NotFound();
            }

            return Ok(brawler);
        }


        // POST: BrawlerController
        [HttpPost(Name = "Create Brawler")]
        public ActionResult<Brawler> Create([FromBody] CreateBrawlerDTO createBrawlerDTO)
        {
            if (ModelState.IsValid)
            {
                var result = _brawlerService.Create(createBrawlerDTO);
                return Created("brawlers", result);

            }
            return BadRequest(ModelState);

        }

  

        // PATCH: BrawlerController/5
        [HttpPatch(Name = "Update Brawler")]
        public ActionResult<int> Edit([FromRoute] int id, [FromBody] UpdateBrawlerDTO updateBrawlerDTO)
        {

            if (id <= 0)
            {
                return BadRequest("Invalid ID");
            }

            if (ModelState.IsValid)
            {
                var result = _brawlerService.Update(id, updateBrawlerDTO);
                if (result == -1) return NotFound();
                return result;
            }

            return BadRequest(ModelState);
        }

 
        // DELETE: BrawlerController/5
        [HttpDelete(Name = "Delete Brawler")]
        public ActionResult<int> Delete([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID");
            }

            var result = _brawlerService.Delete(id);
            if (result == -1)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
