using BrawlFav.DTOs;
using BrawlFav.Models;

namespace BrawlFav.Services;

public static class BrawlerService
{
    static List<Brawler> Brawlers { get; }
    static private int CountId { get; set; }

    static BrawlerService()
    {
        Brawlers = new List<Brawler>();
        CountId = 1;
    }

    public static List<Brawler> GetAll() => Brawlers;

    public static Brawler Create(CreateBrawlerDTO dto)
    {
        Brawler brawl = new()
        {
            Id = CountId,
            Name = dto.Name,
            StarPowers = Array.Empty<StarPower>(),
            Gadgets = Array.Empty<Gadget>()
        };
        Brawlers.Add(brawl);
        CountId++;

        return brawl;
    }

    public static Brawler? GetBrawler(int Id) => Brawlers.Find(b => b.Id == Id);

    public static int Update(UpdateBrawlerDTO dto)
    {
        var brawlerIndex = Brawlers.FindIndex(b => b.Id == dto.Id);

        if (brawlerIndex == -1) return -1;

        Brawlers[brawlerIndex].Name = dto.Name ?? Brawlers[brawlerIndex].Name;

        return Brawlers[brawlerIndex].Id;
    }

    public static int Delete(int Id)
    {
        var brawlerIndex = Brawlers.FindIndex(b => b.Id == Id);
        if (brawlerIndex == -1) return -1;
        Brawlers.RemoveAt(brawlerIndex);
        return 1;
    }
}