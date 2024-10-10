namespace WarcraftApi.DomainServices.Models;

public class WeaponBe
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Damage { get; set; }
    public string Lore { get; set; } = string.Empty;
}