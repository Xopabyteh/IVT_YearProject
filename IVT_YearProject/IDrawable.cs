namespace IVT_YearProject;

public interface IDrawable
{
    public Int2 Position { get; set; }
    public char Sprite { get; set; }
    public ConsoleColor Color { get; set; }
}