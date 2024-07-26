namespace DotNetris.Tests;

[TestClass]
public class GameBoardTest
{

    [TestMethod]
    public void SetGet_Color_SuccessfullySetsAndGets()
    {
        GameBoard gameBoard = new GameBoard();
        
        // Check we can set a value at a position
        gameBoard.Set(0, 0, Color.Red);
        
        // Check it was actually set
        Assert.AreEqual(gameBoard.Get(0, 0), Color.Red);
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Set_InvalidPositionPositiveX_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Set a color outside the board
        gameBoard.Set(GameBoard.Width + 1, 0, Color.Red);
    }
    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Set_InvalidPositionPositiveY_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Set a color outside the board
        gameBoard.Set(0, GameBoard.Height + 1, Color.Red);
    }
    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Set_InvalidPositionNegativeX_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Set a color outside the board
        gameBoard.Set(-1, 0, Color.Red);
    }
    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Set_InvalidPositionNegativeY_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Set a color outside the board
        gameBoard.Set(0, -1, Color.Red);
    }
    
    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Get_InvalidPositionPositiveX_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Get a color outside the board
        gameBoard.Get(GameBoard.Width + 1, 0);
    }
    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Get_InvalidPositionPositiveY_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Get a color outside the board
        gameBoard.Get(0, GameBoard.Height + 1);
    }
    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Get_InvalidPositionNegativeX_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Get a color outside the board
        gameBoard.Get(-1, 0);
    }
    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Get_InvalidPositionNegativeY_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Get a color outside the board
        gameBoard.Get(0, -1);
    }
}