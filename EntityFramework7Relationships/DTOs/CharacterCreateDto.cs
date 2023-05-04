namespace EntityFramework7Relationships.DTOs;

public record struct CharacterCreateDto(
    string Name,
    BackPackCreateDto BackPack,
    List<WeaponCreateDto> Weapons,
    List<FactionCreateDto> Factions);