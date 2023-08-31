using BrawlFav.DTOs;
using BrawlFav.Models;

namespace BrawlFav.Services;

public static class BrawlerService
{
    static List<Brawler> Brawlers { get; }

    static BrawlerService() { Brawlers = new List<Brawler>(); }

    public static List<Brawler> GetAll() => Brawlers;

    public static Brawler Create(CreateBrawlerDTO dto)
    {
        Brawler brawl = new Brawler { Id = Brawlers.Count(), Name = dto.Name, StarPowers = new StarPower[0], Gadgets = new Gadget[0] };
        Brawlers.Add(brawl);

        return brawl;
    }
}