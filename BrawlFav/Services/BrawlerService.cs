using BrawlFav.DTOs;
using BrawlFav.Models;

namespace BrawlFav.Services;

public class BrawlerService: IBrawlerService
{
    private static List<Brawler> Brawlers { get; } = new List<Brawler>();
    private static int CountId { get; set; } = 1;

 

    public List<Brawler> GetAll() => Brawlers;

    public Brawler Create(CreateBrawlerDTO dto)
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

    public Brawler? GetBrawler(int Id) => Brawlers.Find(b => b.Id == Id);

    public int Update(int id, UpdateBrawlerDTO dto)
    {
        var brawlerIndex = Brawlers.FindIndex(b => b.Id == id);

        if (brawlerIndex == -1) return -1;

        Brawlers[brawlerIndex].Name = dto.Name ?? Brawlers[brawlerIndex].Name;

        return Brawlers[brawlerIndex].Id;
    }

    public int Delete(int Id)
    {
        var brawlerIndex = Brawlers.FindIndex(b => b.Id == Id);
        if (brawlerIndex == -1) return -1;
        Brawlers.RemoveAt(brawlerIndex);
        return 1;
    }
}