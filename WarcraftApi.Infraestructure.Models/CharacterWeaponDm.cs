namespace WarcraftApi.Infraestructure.Models;

public class CharacterWeaponDm
{
    public int CharacterId { get; set; }
    public CharacterDm? Character { get; set; }

    public int WeaponId { get; set; }
    public WeaponDm? Weapon { get; set; }
}
