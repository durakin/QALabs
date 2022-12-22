using TDD_Chess;
using TDD_Chess.Pieces;

namespace TDD_ChesssTest;

public class KnightTests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void MoveOnEmptyCorrectField()
    {
        var board = new TChessBoard();
        var field = board.GetField('3', 'F');
        var knight = new TChessmanKnight(Side.SideWhite, field, board);
        var newField = board.GetField('4', 'D'); 
        field.PutChessman(knight);
        knight.GoToPosition(newField).Execute();
        Assert.Multiple(() =>
        {
            Assert.That(newField, Is.SameAs(knight.Field));
            Assert.That(newField.Chessman, Is.SameAs(knight));
            Assert.That(field.Chessman, Is.Null);
        });
    }
    
    
    
    [Test]
    public void MoveOnEmptyWrongField()
    {
        var board = new TChessBoard();
        var field = board.GetField('3', 'F');
        var newField = board.GetField('5', 'F');
        var knight = new TChessmanKnight(Side.SideWhite, field, board);
        field.PutChessman(knight);

        Assert.Multiple(() =>
            {
                Assert.That(() => knight.GoToPosition(newField).Execute(),
                    Throws.Exception
                        .TypeOf<Exception>());
                Assert.That(knight.Field, Is.SameAs(field));
                Assert.That(knight, Is.SameAs(field.Chessman));
                Assert.That(newField.Chessman, Is.Null);
            }
        );
    }

    [Test]
    public void MoveOnFriendlyPieceCorrectField()
    {
        var board = new TChessBoard();
        var field = board.GetField('1', 'G');
        var newField = board.GetField('3', 'G'); 
        var knight = new TChessmanKnight(Side.SideWhite, field, board);
        field.PutChessman(knight);
        var victimKnight = new TChessmanKnight(Side.SideWhite, newField, board);
        newField.PutChessman(victimKnight);
        Assert.Multiple(() =>
            {
                Assert.That(() => knight.GoToPosition(newField).Execute(),
                    Throws.Exception
                        .TypeOf<Exception>());
                Assert.That(knight.Field, Is.SameAs(field));
                Assert.That(victimKnight.Field, Is.SameAs(newField));
                Assert.That(knight, Is.SameAs(field.Chessman));
                Assert.That(victimKnight, Is.SameAs(newField.Chessman));
            }
        );
    }
    
    [Test]
    public void MoveOnEnemyPieceCorrectField()
    {
        var board = new TChessBoard();
        var field = board.GetField('1', 'G');
        var newField = board.GetField('3', 'F'); 
        var knight = new TChessmanKnight(Side.SideWhite, field, board);
        field.PutChessman(knight);
        var victimKnight = new TChessmanKnight(Side.SideBlack, newField, board);
        newField.PutChessman(victimKnight);
        knight.GoToPosition(newField).Execute();
        Assert.Multiple(() =>
            {
                Assert.That(knight.Field, Is.SameAs(newField));
                Assert.That(knight, Is.SameAs(newField.Chessman));
                Assert.That(field.Chessman, Is.Null);
            }
        );
    }
    
    [Test]
    public void MoveOnEnemyKingCorrectField()
    {
        var board = new TChessBoard();
        var field = board.GetField('1', 'G');
        var newField = board.GetField('3', 'F'); 
        var knight = new TChessmanKnight(Side.SideWhite, field, board);
        field.PutChessman(knight);
        var victimKing = new TChessmanKing(Side.SideBlack, newField, board);
        newField.PutChessman(victimKing);
        Assert.Multiple(() =>
            {
                Assert.That(() => knight.GoToPosition(newField).Execute(),
                    Throws.Exception
                        .TypeOf<Exception>());
                Assert.That(knight.Field, Is.SameAs(field));
                Assert.That(victimKing.Field, Is.SameAs(newField));
                Assert.That(knight, Is.SameAs(field.Chessman));
                Assert.That(victimKing, Is.SameAs(newField.Chessman));
            }
        );
    }

}