namespace DotNetris;
/// <summary>
/// Represents a single game
/// </summary>
public class Game
{
    /// <summary>
    /// Create a new game with a random seed
    /// </summary>
    public Game()
    {
        // This does not use secure randomness, but secure randomness does not matter here
        Seed = Random.Shared.Next(int.MinValue, int.MaxValue);
    }
    /// <summary>
    /// Create a game with a fixed seed
    /// </summary>
    /// <param name="seed">The seed to use</param>
    public Game(int seed)
    {
        Seed = seed;
    }
    /// <summary>
    /// The game seed. Used to make the game deterministic.
    /// </summary>
    public int Seed { get; private set; }
    
    /// <summary>
    /// The game board
    /// </summary>
    public GameBoard Board = new GameBoard();

    /// <summary>
    /// The current score for this game
    /// </summary>
    public ulong Score { get; private set; }
    
    /// <summary>
    /// Current game inputs. You should update this whenever you get an event from the user/the network.
    /// </summary>
    public Inputs Inputs { get; set; }

    /// <summary>
    /// How many ticks per second the game should run at for real-time play. If an operation takes X seconds, it takes X * Tickrate Ticks.
    /// </summary>
    public const int Tickrate = 30;
    
    /// <summary>
    /// Move the game forward one tick. Not currently implemented.
    /// </summary>
    public void Tick()
    {
        throw new NotImplementedException();
    }
}