namespace WarcraftApi.DistributedServices.Models;

public class CharacterDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Lore { get; set; } = string.Empty;
    public float Life { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    public List<WeaponDto> Weapons { get; set; } = new List<WeaponDto>();

}