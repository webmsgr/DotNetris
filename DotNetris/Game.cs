namespace DotNetris;
/// <summary>
/// Represents a single game
/// </summary>
public class Game
{
    /// <summary>
    /// Create a new game with a random seed
    /// </summary>
    /// <param name="diff">The game difficulty</param>
    public Game(Difficulty diff)
    {
        // This does not use secure randomness, but secure randomness does not matter here
        Rand = new Random(Random.Shared.Next(int.MinValue, int.MaxValue));
        Bag = new PiecePeekBag(new PieceBag(Rand));
        CurrentPiece = Bag.Next();
        PiecePosition = (3, 1);
        Board = new GameBoard();
        this.Difficulty = diff;
    }

    /// <summary>
    /// Create a game with a fixed seed
    /// </summary>
    /// <param name="seed">The seed to use</param>
    /// <param name="diff">The game difficulty</param>
    public Game(int seed, Difficulty diff)
    {
        Rand = new Random(seed);
        Bag = new PiecePeekBag(new PieceBag(Rand));
        CurrentPiece = Bag.Next();
        PiecePosition = (3, 1);
        Board = new GameBoard();
        this.Difficulty = diff;
    }

    private Difficulty _difficulty;

    /// <summary>
    /// The game's difficulty
    /// </summary>
    public Difficulty Difficulty
    {
        get
        {
            return _difficulty;
        }
        set
        {
            _difficulty = value;
            UpdateToMatchLevelDifficulty();
        }
    }

    

    /// <summary>
    /// The bag to pick pieces out of
    /// </summary>

    public PiecePeekBag Bag;
    /// <summary>
    /// The current piece
    /// </summary>
    public Piece CurrentPiece;
    /// <summary>
    /// Where the current piece is located
    /// </summary>
    public (int, int) PiecePosition;

    /// <summary>
    /// The game seed. Used to make the game deterministic.
    /// </summary>
    public Random Rand;

    /// <summary>
    /// The game board
    /// </summary>
    public GameBoard Board;

    private ulong _score;

    /// <summary>
    /// The current score for this game
    /// </summary>
    public ulong Score
    {
        get => _score;
        private set
        {
            _score = value;
            UpdateToMatchLevelDifficulty();
        }
    }

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

    /// <summary>
    /// How fast the piece drops
    /// </summary>
    public TickTimer PieceDropSpeed = new TickTimer(Tickrate/3);

    //public TickTimer MoveTimer = new TickTimer(Tickrate/15); // pieces move every 1/15th of a second with the keys

    private InputHelper InputHelper = new();

    /// <summary>
    /// The current level
    /// </summary>
    public int Level
    {
        get 
        {
            return (int)(Score / 1000) + 1;
        }
    }

    private void UpdateToMatchLevelDifficulty()
    {
        decimal baseSpeed = -1; // base speed determines the starting speed of the difficulty
        decimal scalingFactor = -1; // scaling factor determines how much faster each level makes the piece.
        switch (Difficulty)
        {
            // TODO: please tweak these to be more balanced
            // or not i dont care
            case Difficulty.Easy:
                baseSpeed = 1;
                scalingFactor = 0.2M;
                break;
            case Difficulty.Normal:
                baseSpeed = 2;
                scalingFactor = 0.5M;
                break;
            case Difficulty.Hard:
                baseSpeed = 4;
                scalingFactor = 1;
                break;
        }
        // add based on level
        decimal speed = (baseSpeed + (scalingFactor * (Level - 1)));
        PieceDropSpeed.Interval = (int)Math.Floor(Tickrate / Math.Floor(speed));
    }

    /// <summary>
    /// Move the game forward one tick. 
    /// </summary>
    public void Tick()
    {
        OnTick.Invoke(this, Inputs);
        InputHelper.Tick(Inputs);
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

        
        {
            if (InputHelper.IsDownThisTick(Inputs.Right) &&
                !Board.DoesPieceCollide(PiecePosition.Item1 + 1, PiecePosition.Item2, CurrentPiece))
            {
                PiecePosition.Item1 += 1;   
            }
            if (InputHelper.IsDownThisTick(Inputs.Left) &&
                !Board.DoesPieceCollide(PiecePosition.Item1 - 1, PiecePosition.Item2, CurrentPiece))
            {
                PiecePosition.Item1 -= 1;   
            }
            if (InputHelper.IsDownThisTick(Inputs.RotateRight))
            {
                var newPiece = CurrentPiece.Rotate();
                if (!Board.DoesPieceCollide(PiecePosition.Item1, PiecePosition.Item2, newPiece))
                {
                    CurrentPiece = newPiece;
                }
            }
            if (InputHelper.IsDownThisTick(Inputs.RotateLeft))
            {
                var newPiece = CurrentPiece.Rotate().Rotate().Rotate(); // bad
                if (!Board.DoesPieceCollide(PiecePosition.Item1, PiecePosition.Item2, newPiece))
                {
                    CurrentPiece = newPiece;
                }
            }
            if (InputHelper.IsDown(Inputs.Down))
            {
                PieceDropSpeed.Left = 1;
            }
        }
        // now, check row clear
        int combo = 0;
        for (int y = 0; y < GameBoard.Height; y++)
        {
            if (Board.GetRow(y)
                .ToArray()
                .All((c) => c != Color.Empty))
            {
                Board.ClearLine(y);
                combo++;
                Score += 100 * (ulong)combo;
            }
        } 
        OnScoreUpdate.Invoke(this, Score);
    }

    

    public event EventHandler<Inputs> OnTick = (sender, inputs) => {};
    public event EventHandler OnLose = (sender, args) => {};
    public event EventHandler<ulong> OnScoreUpdate = (sender, e) => { };
}