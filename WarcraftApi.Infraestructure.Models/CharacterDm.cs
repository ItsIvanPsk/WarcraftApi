namespace WarcraftApi.Infraestructure.Models;

public class CharacterDm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Lore { get; set; }
    public float Life { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }

    public ICollection<CharacterWeaponDm> CharacterWeapons { get; set; }
    
    
}
