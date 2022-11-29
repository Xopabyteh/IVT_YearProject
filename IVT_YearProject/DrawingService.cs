namespace IVT_YearProject;

public class DrawingService
{

    /// <summary>
    /// Draw drawables in the correct culling order
    /// </summary>
    /// <param name="drawableLayers"></param>
    public void DrawLayers(IEnumerable<IDrawable> drawableLayers)
    {
        foreach (var drawable in drawableLayers)
        {
            DrawDrawState(drawable.GetDrawState);
        }
    }

    private void DrawDrawState(DrawState drawable)
    {
        Console.SetCursorPosition(drawable.Position.X * 2, drawable.Position.Y);
        Console.ForegroundColor = drawable.Color;
        Console.Write(drawable.Sprite);
    }
}