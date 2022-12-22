namespace TDD_Chess;

public class TChessField
{
    // 1 through  8
    public char Row { get; }
    
    // A through  H
    public char Col { get; }
    
    public TChessman? Chessman { get; private set; }

    public override string ToString()
    {
        return $"{Col}{Row}";
    }
    
    public void PutChessman(TChessman chessman)
    {
        if (Chessman != null)
        {
            throw new Exception("Trying to move to populated field!");
        }
        Chessman = chessman;
    }

    public void RemoveChessman()
    {
        Chessman = null;
    }

    public TChessField(char row, char col)
    {
        Row = row;
        Col = col;
    }
}