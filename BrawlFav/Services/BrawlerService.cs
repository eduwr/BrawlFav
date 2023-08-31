using BrawlFav.Models;

namespace BrawlFav.Services;

public static class BrawlerService
{
    static List<Brawler> Brawlers { get; }

    static BrawlerService() {  Brawlers = new List<Brawler>();}

    public static List<Brawler> GetAll() => Brawlers;
}