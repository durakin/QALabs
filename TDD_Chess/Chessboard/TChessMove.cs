namespace TDD_Chess;

public class TChessMove
{
    public TChessField OriginalField { get; }
    public TChessField NewField { get; }
    public TChessman? MovedPiece { get; }
    public TChessman? CapturedPiece { get; }
    public bool Executed { get; private set; }

    public override string ToString()
    {
        return $"{OriginalField} -> {NewField} {(CapturedPiece is not null ? "Captured " +  CapturedPiece : "")}";
    }
    
    public TChessMove(TChessField originalField, TChessField newField)
    {
        OriginalField = originalField;
        NewField = newField;
        MovedPiece = originalField.Chessman;
        CapturedPiece = newField.Chessman;
        Executed = false;
    }

    public void Execute()
    {
        if (Executed) throw new Exception("Trying to execute move more than once");
        if (MovedPiece is null) throw new Exception("Trying to move null piece");
        if (CapturedPiece?.Side == MovedPiece.Side) throw new Exception("Trying to capture piece of same side");
        if (CapturedPiece?.PieceType == PieceType.FigureKing) throw new Exception("Trying to capture a king (how is that even possible?)");
        NewField.RemoveChessman();
        NewField.PutChessman(MovedPiece);
        OriginalField.RemoveChessman();
        MovedPiece.Field = NewField;
        MovedPiece.OnMove();
        Console.WriteLine(ToString());
        Executed = true;
    }
}