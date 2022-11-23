namespace IVT_YearProject;

public record class Tile : IDrawable
{
    public Int2 Position { get; set; }
    public char Sprite { get; set; }
    public ConsoleColor Color { get; set; }
    public bool CanWalkHere;
}
