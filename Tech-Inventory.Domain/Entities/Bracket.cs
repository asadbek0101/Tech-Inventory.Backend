namespace Tech_Inventory.Domain.Entities;

public class Bracket : BaseEntity
{
    public int ObyektId { get; set; }
    public int ModelId { get; set; }
    public string? Info { get; set; }
    public BracketTypes BracketType { get; set; }
    public Model Model { get; set; }
    public Obyekt Obyekt { get; set; }
}

public enum BracketTypes
{
    WallBracket = 1,
    PillarBracket = 2,
}