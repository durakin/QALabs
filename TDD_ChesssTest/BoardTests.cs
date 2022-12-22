using TDD_Chess;
using TDD_Chess.Pieces;

namespace TDD_ChesssTest;

public class BoardTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FieldsEdges()
    {
        var board = new TChessBoard();
        var a1Field = board.GetField('1', 'A');
        var h8Field = board.GetField('8', 'H');
        Assert.Multiple(() =>
        {
            Assert.That(a1Field.Row, Is.EqualTo('1'));
            Assert.That(a1Field.Col, Is.EqualTo('A'));
            Assert.That(h8Field.Row, Is.EqualTo('8'));
            Assert.That(h8Field.Col, Is.EqualTo('H'));
        });
    }

    [Test]
    public void FieldsOutOfBounds()
    {
        var board = new TChessBoard();
        Assert.Multiple(() =>
        {
            Assert.That(() => board.GetField('1', (char)('A'-1)),
                Throws.Exception
                    .TypeOf<Exception>());
            Assert.That(() => board.GetField('1', (char)('H'+1)),
                Throws.Exception
                    .TypeOf<Exception>());
            Assert.That(() => board.GetField((char)('1'-1), 'A'),
                Throws.Exception
                    .TypeOf<Exception>());
            Assert.That(() => board.GetField((char)('8'+1), 'A'),
                Throws.Exception
                    .TypeOf<Exception>());
        });
    }
    
    /*
    [Test]
    public void CollideNoCollision()
    {
        var board = new TChessBoard();
        var start = board.GetField('4', 'D');
        var upRight = board.GetField('5', 'E');
        var right = board.GetField('4', 'E');
        var downRight = board.GetField('3', 'E');
        var down = board.GetField('3', 'D');
        var downLeft = board.GetField('3', 'C');
        var left = board.GetField('4', 'C');
        var upLeft = board.GetField('5', 'C');
        var up = board.GetField('5', 'D');
        Assert.Multiple(() =>
        {
            Assert.That(board.Collide(start, upRight), Is.SameAs(start));
            Assert.That(board.Collide(start, right), Is.SameAs(start));
            Assert.That(board.Collide(start, downRight), Is.SameAs(start));
            Assert.That(board.Collide(start, down), Is.SameAs(start));
            Assert.That(board.Collide(start, downLeft), Is.SameAs(start));
            Assert.That(board.Collide(start, left), Is.SameAs(start));
            Assert.That(board.Collide(start, upLeft), Is.SameAs(start));
            Assert.That(board.Collide(start, up), Is.SameAs(start));
        });
    }
    */

    [Test]
    public void CollideNoCollision()
    {
        var board = new TChessBoard();
        var start = board.GetField('4', 'D');
        var upRight = board.GetField('8', 'H');
        Assert.That(board.Collide(start, upRight), Is.SameAs(upRight));

    }
    
    [Test]
    public void CollideCollision()
    {
        var board = new TChessBoard();
        var start = board.GetField('4', 'D');
        var upRight = board.GetField('8', 'H');
        var right = board.GetField('4', 'H');
        var downRight = board.GetField('1', 'G');
        var down = board.GetField('1', 'D');
        var downLeft = board.GetField('1', 'A');
        var left = board.GetField('4', 'A');
        var upLeft = board.GetField('7', 'A');
        var up = board.GetField('8', 'D');

        var upRightPiece = board.GetField('6', 'F');
        upRightPiece.PutChessman(new TChessmanKing(Side.SideBlack, upRightPiece, board));
        
        var rightPiece = board.GetField('4', 'F');
        rightPiece.PutChessman(new TChessmanKing(Side.SideBlack, rightPiece, board));
        
        var downRightPiece = board.GetField('2', 'F');
        downRightPiece.PutChessman(new TChessmanKing(Side.SideBlack, downRightPiece, board));
        
        var downPiece = board.GetField('2', 'D');
        downPiece.PutChessman(new TChessmanKing(Side.SideBlack, downPiece, board));
        
        var downLeftPiece = board.GetField('2', 'B');
        downLeftPiece.PutChessman(new TChessmanKing(Side.SideBlack, downLeftPiece, board));
        
        var leftPiece = board.GetField('4', 'B');
        leftPiece.PutChessman(new TChessmanKing(Side.SideBlack, leftPiece, board));
        
        var upLeftPiece = board.GetField('6', 'B');
        upLeftPiece.PutChessman(new TChessmanKing(Side.SideBlack, upLeftPiece, board));
        
        var upPiece = board.GetField('6', 'D');
        upPiece.PutChessman(new TChessmanKing(Side.SideBlack, upPiece, board));
        
        Assert.Multiple(() =>
        {
            Assert.That(board.Collide(start, upRight), Is.SameAs(upRightPiece));
            Assert.That(board.Collide(start, right), Is.SameAs(rightPiece));
            Assert.That(board.Collide(start, downRight), Is.SameAs(downRightPiece));
            Assert.That(board.Collide(start, down), Is.SameAs(downPiece));
            Assert.That(board.Collide(start, downLeft), Is.SameAs(downLeftPiece));
            Assert.That(board.Collide(start, left), Is.SameAs(leftPiece));
            Assert.That(board.Collide(start, upLeft), Is.SameAs(upLeftPiece));
            Assert.That(board.Collide(start, up), Is.SameAs(upPiece));
        });
    }
    
}