namespace TDD_Chess;

public interface IChessman
{
    public TChessField GetPosition();
    public TChessMove GoToPosition(TChessField field);
}