namespace WarcraftApi.Infraestructure.Models;

public class CharacterDm
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Lore { get; set; } = string.Empty;
    public float Life { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
}