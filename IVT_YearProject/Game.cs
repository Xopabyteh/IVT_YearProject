using System.Text;

namespace IVT_YearProject;

public class Game
{

    private readonly float fps;
    private readonly InputService inputService;
    private bool running = true;
    public Game(float fps)
    {
        this.fps = fps;
        inputService = new InputService();
    }

    public void Init()
    {
        Console.Clear();
        Start();

        var updateSleep = TimeSpan.FromSeconds(1.0f / fps);
        while (running)
        {
            Update();
            Thread.Sleep(updateSleep);
        }

        Console.WriteLine("Aborted");
        // ReSharper disable once FunctionNeverReturns
    }

    private Board board;
    private Player player;
    private void Start()
    {
        board = new Board(6, 6);
        player = new Player()
        {
            Color = ConsoleColor.Gray,
            Position = new Int2(3,3),
            Sprite = 'I'
        };
    }

    private void Update()
    {
        var inputQueue = inputService.ReadQueue();
        Int2 moveDir = new Int2(0,0);
        foreach (var consoleKeyInfo in inputQueue)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Escape:
                    running = false;
                    return;
                case ConsoleKey.LeftArrow:
                    moveDir = new Int2(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    moveDir = new Int2(1, 0);
                    break;
                case ConsoleKey.UpArrow:
                    moveDir = new Int2(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    moveDir = new Int2(0, 1);
                    break;
            }
        }

        player.Position += moveDir;
        DrawFull();
    }

    private void DrawFull()
    {
        //Draw tiles
        foreach (var tile in board.TilesDictionary)
        {
            DrawDrawable(tile.Value);
        }
        //Draw player
        DrawDrawable(player);

        //Flush
        Console.WriteLine();
    }

    private void DrawDrawable(IDrawable drawable)
    {
        Console.SetCursorPosition(drawable.Position.X, drawable.Position.Y);
        Console.ForegroundColor = drawable.Color;
        Console.Write(drawable.Sprite);
    }
}