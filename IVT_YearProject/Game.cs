using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Text;
using IVT_YearProject.Entities;
using IVT_YearProject.Properties;

namespace IVT_YearProject;

public class Game
{

    private readonly float fps;
    private bool running = true;

    private readonly InputService inputService;
    private DrawingService drawingService;
    private SceneService sceneService;

    public Game(float fps)
    {
        this.fps = fps;
        inputService = new InputService();
        drawingService = new DrawingService();
        sceneService = new SceneService();
    }

    public void Init()
    {
        Console.Title = "IVT Year project";
        
        Console.CursorVisible = false;
        Console.Clear();



        var updateSleep = TimeSpan.FromSeconds(1.0f / fps);
        while (running)
        {
            Update();
            Thread.Sleep(updateSleep);
        }

        Console.WriteLine("Aborted");
        // ReSharper disable once FunctionNeverReturns
    }


    private void Update()
    {
        //var inputQueue = inputService.ReadQueue();
        //Int2 moveDir = new Int2(0,0);
        //foreach (var consoleKeyInfo in inputQueue)
        //{
        //    switch (consoleKeyInfo.Key)
        //    {
        //        case ConsoleKey.Escape:
        //            running = false;
        //            return;
        //        case ConsoleKey.LeftArrow:
        //            moveDir = new Int2(-1, 0);
        //            break;
        //        case ConsoleKey.RightArrow:
        //            moveDir = new Int2(1, 0);
        //            break;
        //        case ConsoleKey.UpArrow:
        //            moveDir = new Int2(0, -1);
        //            break;
        //        case ConsoleKey.DownArrow:
        //            moveDir = new Int2(0, 1);
        //            break;
        //    }
        //}
    }
}