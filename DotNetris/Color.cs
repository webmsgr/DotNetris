namespace DotNetris;

public enum Color: byte
{
    Empty = 0, // The default value of an enum is 0, so Empty is our default.
    Red,
    Orange,
    Yellow,
    Green,
    Blue,
    Purple,

    /// <summary>
    ///  Used internally for drawing, don't use
    /// </summary>
    Void

    
}


public static class ColorExtensions
{
    public static System.Drawing.Color ToDrawable(this Color c)
    {
        return c switch
        {
            Color.Empty => System.Drawing.Color.Black,
            Color.Red => System.Drawing.Color.Red,
            Color.Orange => System.Drawing.Color.Orange,
            Color.Yellow => System.Drawing.Color.Yellow,
            Color.Green => System.Drawing.Color.Green,
            Color.Blue => System.Drawing.Color.Blue,
            Color.Purple => System.Drawing.Color.Purple,
            _ => throw new NotImplementedException(),
        };
    }
}