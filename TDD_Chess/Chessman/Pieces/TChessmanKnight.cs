namespace TDD_Chess.Pieces;

public class TChessmanKnight : TChessman
{
    public TChessmanKnight(Side side, TChessField field, TChessBoard board) : base(PieceType.FigureKnight, side, field, board)
    {
    }

    protected override bool AcceptableMove(TChessField newField)
    {
        var horMove = newField.Col - Field.Col;
        var verMove = newField.Row - Field.Row;
        if (horMove == 0 || verMove == 0) return false;
        return Math.Abs(horMove) + Math.Abs(verMove) == 3;
    }

    public override void OnMove()
    {
        
    }
}