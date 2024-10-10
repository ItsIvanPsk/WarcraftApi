namespace WarcraftApi.Infraestructure.Models;

public class WeaponDm
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Damage { get; set; }
    public string Lore { get; set; } = string.Empty;

    public ICollection<CharacterWeaponDm> CharacterWeapons { get; set; }
}
