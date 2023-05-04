namespace EntityFramework7Relationships.Models;

public class Character
{
    public int Id { get; set; }

    public string Name { get; set; }
    // I had to remove the backpackid when i got an error message
    // The dependent side could not be determined for the one-to-one relationship between
    // 'BackPack.Character' and 'Character.BackPack'.
    // To identify the dependent side of the relationship,
    // configure the foreign key property. If these navigations should not be part of the same relationship, configure them independently via separate method chains in 'OnModelCreating'.
    // See http://go.microsoft.com/fwlink/?LinkId=724062 for more details. 

    // public int BackPackId { get; set; }
    public BackPack BackPack { get; set; }
    public List<Weapon> Weapons { get; set; }
    public List<Faction> Factions { get; set; }
}