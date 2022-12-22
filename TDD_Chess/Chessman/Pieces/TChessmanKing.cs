namespace TDD_Chess.Pieces;

public class TChessmanKing : TChessman
{
    public TChessmanKing(Side side, TChessField field, TChessBoard board) : base(PieceType.FigureKing, side, field, board)
    {
    }

    protected override bool AcceptableMove(TChessField newField)
    {
        throw new NotImplementedException();
    }

    public override void OnMove()
    {
        throw new NotImplementedException();
    }
}