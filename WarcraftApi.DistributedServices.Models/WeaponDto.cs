namespace WarcraftApi.DistributedServices.Models;

public class WeaponDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Damage { get; set; }
    public string Lore { get; set; } = string.Empty;
}