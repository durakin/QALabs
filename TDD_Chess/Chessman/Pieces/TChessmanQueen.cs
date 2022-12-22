namespace TDD_Chess.Pieces;

public class TChessmanQueen : TChessman
{
    public TChessmanQueen(Side side, TChessField field, TChessBoard board) : base(PieceType.FigureQueen, side, field, board)
    {
    }

    private bool AcceptableCollision(TChessField newField)
    {
        return Board.Collide(Field, newField) == newField;
    }

    protected override bool AcceptableMove(TChessField newField)
    {
        var horMove = newField.Col - Field.Col;
        var verMove = newField.Row - Field.Row;
        if (horMove == 0 && verMove != 0) return AcceptableCollision(newField);
        if (horMove != 0 && verMove == 0) return AcceptableCollision(newField);
        if (Math.Abs(horMove) == Math.Abs(verMove)) return AcceptableCollision(newField);
        return false;
    }

    public override void OnMove()
    {
        
    }
}