public class Map
{
    public Point Origin { get; set;}
    public Point Size { get; }

    private int[][] mapData;
    private Dictionary<CellType, char> cellVisuals = new Dictionary<CellType, char>{
        { CellType.Empty, ' '},
        { CellType.WallHorizontal, '-'},
        { CellType.WallVertical, '|'},
        { CellType.WallCorner, '+'},
        { CellType.Teleport, '♨'},
        { CellType.Floor, '.'},
        { CellType.Water, '~'},
        { CellType.Shop, '💰'},

    }
    private CellType[] walkableCellTypes = new CellType[] { 
        CellType.Floor, 
        CellType.Grass,
        CellType.Teleport,
        CellType.Shop,
    };
    
    };
