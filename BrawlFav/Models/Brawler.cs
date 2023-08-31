namespace BrawlFav.Models;

public class Brawler
{
    public int   Id { get; set; }
    public required string Name { get; set; }
    public required StarPower[] StarPowers { get; set; }
    public required Gadget[] Gadgets { get; set; }

}