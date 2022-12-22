namespace TDD_Chess;

public abstract class TChessman : IChessman
{
    public PieceType PieceType { get; }
    public Side Side { get; }
    public TChessField Field { get; set; }
    
    public TChessBoard Board { get; }

    public TChessman(PieceType pieceType, Side side, TChessField field, TChessBoard board)
    {
        PieceType = pieceType;
        Side = side;
        Field = field;
        Board = board;
    }

    public TChessField GetPosition()
    {
        return Field;
    }

    protected abstract bool AcceptableMove(TChessField newField);
    
    public TChessMove GoToPosition(TChessField field)
    {
        if (!AcceptableMove(field)) throw new Exception("Unacceptable move!");
        var move = new TChessMove(Field, field);
        return move;
    }

    public abstract void OnMove();
}