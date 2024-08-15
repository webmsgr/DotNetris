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
        Rand = new Random(Random.Shared.Next(int.MinValue, int.MaxValue));
        Bag = new PiecePeekBag(new PieceBag(Rand));
        CurrentPiece = Bag.Next();
        PiecePosition = (3, 1);
        Board = new GameBoard();
    }



    /// <summary>
    /// Create a game with a fixed seed
    /// </summary>
    /// <param name="seed">The seed to use</param>
    public Game(int seed)
    {
        Rand = new Random(seed);
        Bag = new PiecePeekBag(new PieceBag(Rand));
        CurrentPiece = Bag.Next();
        PiecePosition = (3, 1);
        Board = new GameBoard();
    }


    public PiecePeekBag Bag;
    public Piece CurrentPiece;
    public (int, int) PiecePosition;

    /// <summary>
    /// The game seed. Used to make the game deterministic.
    /// </summary>
    public Random Rand;

    /// <summary>
    /// The game board
    /// </summary>
    public GameBoard Board;

    /// <summary>
    /// The current score for this game
    /// </summary>
    public ulong Score { get; private set; }

    /// <summary>
    /// Current game inputs. You should update this whenever you get an event from the user/the network.
    /// </summary>
    public Inputs Inputs { get; set; } = Inputs.None;

    /// <summary>
    /// Sets one or more input flags. Call this in your keydown event handler
    /// </summary>
    /// <param name="input">Flags to set</param>
    public void SetInput(Inputs input)
    {
        this.Inputs |= input;
    }
    /// <summary>
    /// Clears one or more input flags. Call this in your keyup event handler
    /// </summary>
    /// <param name="input">Flags to clear</param>
    public void ClearInput(Inputs input)
    {
        this.Inputs &= ~input;
    }
    
    /// <summary>
    /// How many ticks per second the game should run at for real-time play. If an operation takes X seconds, it takes X * Tickrate Ticks.
    /// </summary>
    public const int Tickrate = 30;


    public TickTimer PieceDropSpeed = new TickTimer(Tickrate/3);

    public TickTimer MoveTimer = new TickTimer(Tickrate/15); // pieces move every 1/15th of a second with the keys

    /// <summary>
    /// Move the game forward one tick. Not currently implemented.
    /// </summary>
    public void Tick()
    {
        OnTick.Invoke(this, Inputs);
        if (PieceDropSpeed.Tick())
        {
            if (!Board.DoesPieceCollide(PiecePosition.Item1, PiecePosition.Item2+1, CurrentPiece))
            {
                PiecePosition.Item2 += 1;
            }
            else
            {
                Board.ApplyPiece(PiecePosition.Item1, PiecePosition.Item2, CurrentPiece);
                PiecePosition = (3, 1);
                CurrentPiece = Bag.Next();
                if (Board.DoesPieceCollide(3, 1, CurrentPiece))
                {
                    OnLose.Invoke(this, null);
                }
            }
        }

        if (MoveTimer.Tick())
        {
            if (Inputs.HasFlag(Inputs.Right) &&
                !Board.DoesPieceCollide(PiecePosition.Item1 + 1, PiecePosition.Item2, CurrentPiece))
            {
                PiecePosition.Item1 += 1;   
            }
            if (Inputs.HasFlag(Inputs.Left) &&
                !Board.DoesPieceCollide(PiecePosition.Item1 - 1, PiecePosition.Item2, CurrentPiece))
            {
                PiecePosition.Item1 -= 1;   
            }
            if (Inputs.HasFlag(Inputs.RotateRight))
            {
                var newPiece = CurrentPiece.Rotate();
                if (!Board.DoesPieceCollide(PiecePosition.Item1, PiecePosition.Item2, newPiece))
                {
                    CurrentPiece = newPiece;
                }
            }
            if (Inputs.HasFlag(Inputs.RotateLeft))
            {
                var newPiece = CurrentPiece.Rotate().Rotate().Rotate(); // bad
                if (!Board.DoesPieceCollide(PiecePosition.Item1, PiecePosition.Item2, newPiece))
                {
                    CurrentPiece = newPiece;
                }
            }
            if (Inputs.HasFlag(Inputs.Down))
            {
                PieceDropSpeed.Left = 1;
            }
        }
    }

    

    public event EventHandler<Inputs> OnTick = (sender, inputs) => {};
    public event EventHandler OnLose = (sender, args) => {};
}