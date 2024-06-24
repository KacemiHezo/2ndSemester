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
        { CellType.Grass, '.'},
        { CellType.Water, '~'},
        { CellType.Shop, '💰'},
        { CellType.Rod, '⚓'},
    };

        private Dictionary<CellType, ConsoleColor> colorMap = new Dictionary<CellType, ConsoleColor> {
        { CellType.Empty, ConsoleColor.Black},
        { CellType.WallCorner, ConsoleColor.DarkRed},
        { CellType.WallHorizontal, ConsoleColor.DarkRed},
        { CellType.WallVertical, ConsoleColor.DarkRed},
        { CellType.Teleport, ConsoleColor.Magenta},
        { CellType.Grass, ConsoleColor.Green},
        { CellType.Water, ConsoleColor.DarkCyan},
        { CellType.Rod, ConsoleColor.DarkCyan},
    };

    private CellType[] walkableCellTypes = new CellType[] { 
        CellType.Floor, 
        CellType.Grass,
        CellType.Teleport,
        CellType.Shop,
        CellType.Rod,
    };
    

    public Map()
    {
        mapData = new int[][] {
            new []{0,3,1,1,1,1,1,3,0,0,3,1,1,1,1,3,0,},
            new []{0,2,6,6,6,6,6,2,0,0,2,8,5,5,9,2,0,},
            new []{0,2,6,6,6,6,6,2,0,0,2,5,5,5,9,2,0,},
            new []{0,2,6,6,6,6,6,2,0,0,2,5,5,5,9,2,0,},
            new []{0,2,5,5,5,5,5,2,0,0,2,5,5,3,1,3,0,},
            new []{0,2,5,5,5,5,5,2,0,0,2,5,3,0,0,0,0,},
            new []{0,3,1,1,1,3,5,2,0,0,2,5,2,0,0,0,0,},
            new []{0,0,0,0,0,2,5,2,0,0,2,5,2,0,0,0,0,},
            new []{0,0,0,0,0,2,5,2,0,0,2,5,2,0,0,0,0,},
            new []{0,0,0,0,0,2,5,2,0,0,2,5,2,0,0,0,0,},
            new []{0,0,0,0,0,2,4,2,0,0,2,4,2,0,0,0,0,},
            new []{0,0,0,0,0,3,1,3,0,0,3,1,3,0,0,0,0,},
        };

        int y = mapData.Length;
        int x = 0;

        foreach (int[] row in mapData)
        {
            if (row.Length > x)
            {
                x = row.Length;
            }
        }

        Size = new Point(x, y);
        Origin = new Point(0, 0);
    }

    public CellType GetCellAt(Point point)
    {
        return GetCellAt(point.X, point.Y);
    }

    private CellType GetCellAt(int x, int y)
    {
        return (CellType)mapData[y][x];
    }

    public char GetCellVisualAt(Point point)
    {
        return cellVisuals[GetCellAt(point)];
    }

    public void Display(Point origin)
    {
        Origin = origin;
        Console.CursorTop = origin.Y;
        for (int y = 0; y < mapData.Length; y++)
        {
            Console.CursorLeft = origin.X;
            for (int x = 0; x < mapData[y].Length; x++)
            {
                var cellValue = GetCellAt(x, y);
                var cellVisual = cellVisuals[cellValue];
                var cellColor = GetCellColorByValue(cellValue);
                Console.ForegroundColor = cellColor;
                Console.Write(cellVisual);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }


    internal bool IsPointCorrect(Point point)
    {
        if (point.Y >= 0 && point.Y < mapData.Length)
        {
            if (point.X >= 0 && point.X < mapData[point.Y].Length)
            {
                if (walkableCellTypes.Contains(GetCellAt(point)))
                {
                    return true;
                }
            }
        }

        return false;
    }


    };
