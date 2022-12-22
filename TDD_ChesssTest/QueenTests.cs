using TDD_Chess;
using TDD_Chess.Pieces;

namespace TDD_ChesssTest;

public class QueenTests
{
    [Test]
    public void MoveOnEmptyCorrectFieldDiag()
    {
        var board = new TChessBoard();
        var field = board.GetField('4', 'D');
        var queen = new TChessmanQueen(Side.SideWhite, field, board);
        var newField = board.GetField('7', 'G'); 
        field.PutChessman(queen);
        queen.GoToPosition(newField).Execute();
        Assert.Multiple(() =>
        {
            Assert.That(newField, Is.SameAs(queen.Field));
            Assert.That(newField.Chessman, Is.SameAs(queen));
            Assert.That(field.Chessman, Is.Null);
        });
    }
    
    [Test]
    public void MoveOnEmptyCorrectFieldHor()
    {
        var board = new TChessBoard();
        var field = board.GetField('4', 'D');
        var queen = new TChessmanQueen(Side.SideWhite, field, board);
        var newField = board.GetField('4', 'A'); 
        field.PutChessman(queen);
        queen.GoToPosition(newField).Execute();
        Assert.Multiple(() =>
        {
            Assert.That(newField, Is.SameAs(queen.Field));
            Assert.That(newField.Chessman, Is.SameAs(queen));
            Assert.That(field.Chessman, Is.Null);
        });
    }
    
    [Test]
    public void MoveOnEmptyCorrectFieldVer()
    {
        var board = new TChessBoard();
        var field = board.GetField('4', 'D');
        var queen = new TChessmanQueen(Side.SideWhite, field, board);
        var newField = board.GetField('1', 'D'); 
        field.PutChessman(queen);
        queen.GoToPosition(newField).Execute();
        Assert.Multiple(() =>
        {
            Assert.That(newField, Is.SameAs(queen.Field));
            Assert.That(newField.Chessman, Is.SameAs(queen));
            Assert.That(field.Chessman, Is.Null);
        });
    }

    [Test]
    public void MoveOnEmptyWrongField()
    {
        var board = new TChessBoard();
        var field = board.GetField('4', 'D');
        var newField = board.GetField('6', 'E');
        var queen = new TChessmanQueen(Side.SideWhite, field, board);
        field.PutChessman(queen);

        Assert.Multiple(() =>
            {
                Assert.That(() => queen.GoToPosition(newField).Execute(),
                    Throws.Exception
                        .TypeOf<Exception>());
                Assert.That(queen.Field, Is.SameAs(field));
                Assert.That(queen, Is.SameAs(field.Chessman));
                Assert.That(newField.Chessman, Is.Null);
            }
        );
    }

    [Test]
    public void MoveOnFriendlyPieceCorrectField()
    {
        var board = new TChessBoard();
        var field = board.GetField('4', 'D');
        var newField = board.GetField('6', 'F'); 
        var queen = new TChessmanQueen(Side.SideWhite, field, board);
        field.PutChessman(queen);
        var victimKnight = new TChessmanKnight(Side.SideWhite, newField, board);
        newField.PutChessman(victimKnight);
        Assert.Multiple(() =>
            {
                Assert.That(() => queen.GoToPosition(newField).Execute(),
                    Throws.Exception
                        .TypeOf<Exception>());
                Assert.That(queen.Field, Is.SameAs(field));
                Assert.That(victimKnight.Field, Is.SameAs(newField));
                Assert.That(queen, Is.SameAs(field.Chessman));
                Assert.That(victimKnight, Is.SameAs(newField.Chessman));
            }
        );
    }
    
    [Test]
    public void MoveOnEnemyPieceCorrectField()
    {
        var board = new TChessBoard();
        var field = board.GetField('4', 'D');
        var newField = board.GetField('6', 'F'); 
        var queen = new TChessmanQueen(Side.SideWhite, field, board);
        field.PutChessman(queen);
        var victimKnight = new TChessmanKnight(Side.SideBlack, newField, board);
        newField.PutChessman(victimKnight);
        queen.GoToPosition(newField).Execute();
        Assert.Multiple(() =>
            {
                Assert.That(queen.Field, Is.SameAs(newField));
                Assert.That(queen, Is.SameAs(newField.Chessman));
                Assert.That(field.Chessman, Is.Null);
            }
        );
    }
    
    [Test]
    public void MoveOnEnemyKingCorrectField()
    {
        var board = new TChessBoard();
        var field = board.GetField('4', 'D');
        var newField = board.GetField('6', 'F'); 
        var queen = new TChessmanQueen(Side.SideWhite, field, board);
        field.PutChessman(queen);
        var victimKing = new TChessmanKing(Side.SideBlack, newField, board);
        newField.PutChessman(victimKing);
        Assert.Multiple(() =>
            {
                Assert.That(() => queen.GoToPosition(newField).Execute(),
                    Throws.Exception
                        .TypeOf<Exception>());
                Assert.That(queen.Field, Is.SameAs(field));
                Assert.That(victimKing.Field, Is.SameAs(newField));
                Assert.That(queen, Is.SameAs(field.Chessman));
                Assert.That(victimKing, Is.SameAs(newField.Chessman));
            }
        );
    }

    [Test]
    public void MoveOnCorrectFieldBlocked()
    {
        var board = new TChessBoard();
        var field = board.GetField('4', 'D');
        var newField = board.GetField('7', 'G');
        var blockField = board.GetField('6', 'F');
        var queen = new TChessmanQueen(Side.SideWhite, field, board);
        field.PutChessman(queen);
        var blockingKnight = new TChessmanKnight(Side.SideBlack, blockField, board);
        blockField.PutChessman(blockingKnight);
        Assert.Multiple(() =>
            {
                Assert.That(() => queen.GoToPosition(newField).Execute(),
                    Throws.Exception
                        .TypeOf<Exception>());
                Assert.That(queen.Field, Is.SameAs(field));
                Assert.That(blockingKnight.Field, Is.SameAs(blockField));
                Assert.That(queen, Is.SameAs(field.Chessman));
                Assert.That(blockingKnight, Is.SameAs(blockField.Chessman));
                Assert.That(newField.Chessman, Is.Null);
            }
        );
    }
}