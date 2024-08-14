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
    [ExpectedException(typeof(ArgumentException), $"X outside valid range. Expected [0..9), found 128")]
    public void Set_InvalidPositionPositiveX_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Set a color outside the board
        gameBoard.Set(128, 0, Color.Red);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), $"Y outside valid range. Expected [0..19), found 128")]
    public void Set_InvalidPositionPositiveY_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Set a color outside the board
        gameBoard.Set(0, 128, Color.Red);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), $"X outside valid range. Expected [0..9), found -1")]
    public void Set_InvalidPositionNegativeX_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Set a color outside the board
        gameBoard.Set(-1, 0, Color.Red);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), $"Y outside valid range. Expected [0..19), found -1")]
    public void Set_InvalidPositionNegativeY_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Set a color outside the board
        gameBoard.Set(0, -1, Color.Red);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), $"X outside valid range. Expected [0..9), found 128")]
    public void Get_InvalidPositionPositiveX_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Get a color outside the board
        gameBoard.Get(128, 0);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), $"Y outside valid range. Expected [0..19), found 128")]
    public void Get_InvalidPositionPositiveY_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Get a color outside the board
        gameBoard.Get(0, 128);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), $"X outside valid range. Expected [0..9), found -1")]
    public void Get_InvalidPositionNegativeX_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Get a color outside the board
        gameBoard.Get(-1, 0);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException), $"Y outside valid range. Expected [0..19), found -1")]
    public void Get_InvalidPositionNegativeY_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        // Get a color outside the board
        gameBoard.Get(0, -1);
    }


    [TestMethod]
    public void GetRow_ValidCords_Works()
    {
        GameBoard gameBoard = new GameBoard();
        Span<Color> row = gameBoard.GetRow(3);
        row[0] = Color.Red;
        row[2] = Color.Orange;
        row[4] = Color.Yellow;
        row[6] = Color.Green;
        row[8] = Color.Blue;
        
        Assert.AreEqual(gameBoard.Get(0, 3), Color.Red);
        Assert.AreEqual(gameBoard.Get(2, 3), Color.Orange);
        Assert.AreEqual(gameBoard.Get(4, 3), Color.Yellow);
        Assert.AreEqual(gameBoard.Get(6, 3), Color.Green);
        Assert.AreEqual(gameBoard.Get(8, 3), Color.Blue);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException), $"Y outside valid range. Expected [0..19), found -1")]
    public void GetRow_InvalidRow_ThrowsException()
    {
        GameBoard gameBoard = new GameBoard();
        Span<Color> row = gameBoard.GetRow(-1);
    }

    [TestMethod]
    public void ClearLine_SingleLine_Works()
    {
        GameBoard gameBoard = new GameBoard();
        gameBoard.GetRow(4).Fill(Color.Green);
        gameBoard.GetRow(3).Fill(Color.Blue);
        gameBoard.GetRow(2).Fill(Color.Red);
        gameBoard.GetRow(1).Fill(Color.Orange);
        gameBoard.ClearLine(3);
        CollectionAssert.AreEqual(Enumerable.Repeat(Color.Green, GameBoard.Width).ToArray(), gameBoard.GetRow(4).ToArray()); // the row below was preserved
        CollectionAssert.AreEqual(Enumerable.Repeat(Color.Red, GameBoard.Width).ToArray(), gameBoard.GetRow(3).ToArray());
        CollectionAssert.AreEqual(Enumerable.Repeat(Color.Orange, GameBoard.Width).ToArray(), gameBoard.GetRow(2).ToArray());
        CollectionAssert.AreEqual(Enumerable.Repeat(Color.Empty, GameBoard.Width).ToArray(), gameBoard.GetRow(1).ToArray());
        CollectionAssert.AreEqual(Enumerable.Repeat(Color.Empty, GameBoard.Width).ToArray(), gameBoard.GetRow(0).ToArray());
    }
    [TestMethod]
    public void ClearLines_Valid_Works()
    {
        GameBoard gameBoard = new GameBoard();
        gameBoard.GetRow(4).Fill(Color.Green);
        gameBoard.GetRow(3).Fill(Color.Blue);
        gameBoard.GetRow(2).Fill(Color.Red);
        gameBoard.GetRow(1).Fill(Color.Orange);
        gameBoard.ClearLines(3, 2); // This clears both the Blue row and the Red row.
        CollectionAssert.AreEqual(Enumerable.Repeat(Color.Green, GameBoard.Width).ToArray(), gameBoard.GetRow(4).ToArray()); // the row below was preserved
        CollectionAssert.AreEqual(Enumerable.Repeat(Color.Orange, GameBoard.Width).ToArray(), gameBoard.GetRow(3).ToArray());
        CollectionAssert.AreEqual(Enumerable.Repeat(Color.Empty, GameBoard.Width).ToArray(), gameBoard.GetRow(2).ToArray());
        CollectionAssert.AreEqual(Enumerable.Repeat(Color.Empty, GameBoard.Width).ToArray(), gameBoard.GetRow(1).ToArray());
        CollectionAssert.AreEqual(Enumerable.Repeat(Color.Empty, GameBoard.Width).ToArray(), gameBoard.GetRow(0).ToArray());
    }
}