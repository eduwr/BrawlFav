using BrawlFav.DTOs;
using BrawlFav.Models;
using System.Collections.Generic;


namespace BrawlFav.Services
{
    public interface IBrawlerService
    {
        List<Brawler> GetAll();
        Brawler Create(CreateBrawlerDTO dto);
        Brawler? GetBrawler(int Id);
        int Update(UpdateBrawlerDTO dto);
        int Delete(int Id);
    }
}