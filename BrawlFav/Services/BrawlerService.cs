using BrawlFav.Models;

namespace BrawlFav.Services;

public static class BrawlerService
{
    static List<Brawler> Brawlers { get; }

    static BrawlerService() { Brawlers = new List<Brawler>(); }

    public static List<Brawler> GetAll() => Brawlers;

    public static Brawler Create()
    {
        Brawler brawl = new Brawler { Id = 1, Name = "test", StarPowers = new StarPower[0], Gadgets = new Gadget[0] };
        Brawlers.Add(brawl);

        return brawl;
    }
}