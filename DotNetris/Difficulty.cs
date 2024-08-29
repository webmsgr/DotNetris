namespace DotNetris;

public enum Difficulty
{
    Easy,
    Normal,
    Hard
}

public static class DifficultyExt
{
    public static DotNetris.Network.Protocol.Difficulty ToNetwork(this Difficulty difficulty)
    {
        return difficulty switch
        {
            Difficulty.Easy => DotNetris.Network.Protocol.Difficulty.Easy,
            Difficulty.Normal => DotNetris.Network.Protocol.Difficulty.Medium,
            Difficulty.Hard => DotNetris.Network.Protocol.Difficulty.Hard,
            _ => throw new ArgumentException("Invalid difficulty"),
        };
    }

    public static Difficulty FromNetwork(DotNetris.Network.Protocol.Difficulty difficulty)
    {
        return difficulty switch
        {
            DotNetris.Network.Protocol.Difficulty.Easy => Difficulty.Easy,
            DotNetris.Network.Protocol.Difficulty.Medium => Difficulty.Normal,
            DotNetris.Network.Protocol.Difficulty.Hard => Difficulty.Hard,
            _ => throw new ArgumentException("Invalid difficulty"),
        };
    }
}