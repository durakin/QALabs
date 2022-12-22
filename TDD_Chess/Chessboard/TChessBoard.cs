using System.Data;

namespace TDD_Chess;

public class TChessBoard
{
    public List<TChessField> Fields;

    // Func<char, char, TChessman> positioner
    public TChessBoard()
    {
        Fields = new List<TChessField>();
        for (var row = 0; row < 8; row++)
        {
            for (var col = 0; col < 8; col++)
            {
                var rowChar = (char)('1' + row);
                var colChar = (char)('A' + col);
                var newField = new TChessField(rowChar, colChar);
                Fields.Add(newField);
            }
        }
    }

    public TChessField GetField(char row, char col)
    {
        return Fields.Find(x => x.Row == row && x.Col == col) ?? throw new Exception("Field out of board's bounds");
    }

    public TChessField Collide(TChessField startField, TChessField newField)
    {
        var currentField = startField;
        var directionX = 0;
        var directionY = 0;
        if (newField.Col - startField.Col > 0) directionX = 1;
        if (newField.Col - startField.Col < 0) directionX = -1;

        if (newField.Row - startField.Row > 0) directionY = 1;
        if (newField.Row - startField.Row < 0) directionY = -1;
        
        do
        {
            try
            {
                currentField = GetField((char)(currentField.Row + directionY), (char)(currentField.Col + directionX));
            }
            catch (Exception e)
            {
                return startField;
            }
            
        } while (currentField.Chessman is null && currentField != newField);

        return currentField;
    }
}