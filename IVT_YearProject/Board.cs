namespace IVT_YearProject;

public record class Board
{
    public IDictionary<Int2,Tile> TilesDictionary { get; set; }

    public Board(int width, int height)
    {
       TilesDictionary = CreateBoard(width,height);
    }

    private IDictionary<Int2,Tile> CreateBoard(int width, int height)
    {
        var board = new Dictionary<Int2, Tile>(width * height);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var pos = new Int2(x, y);
                board.Add(pos, new Tile()
                        {
                            Position = pos,
                            Sprite = ' ',
                            CanWalkHere = false
                        });
            }
        }

        return board;
    }
}