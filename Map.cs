using System.Diagnostics;
using System.Drawing;

public class Map
{
    public Point Origin { get; set;}
    public Point Size { get; }

    private readonly int[][] mapData;
    private readonly Dictionary<Point, Point> _teleports = new();
    private Dictionary<CellType, char> cellVisuals = new Dictionary<CellType, char>{
        { CellType.Empty, ' '},
        { CellType.WallHorizontal, '-'},
        { CellType.WallVertical, '|'},
        { CellType.WallCorner, '+'},
        { CellType.Teleport, '♨'},
        { CellType.Grass, '.'},
        { CellType.Water, '~'},
        { CellType.Shop, 'x'},
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
        { CellType.Shop, ConsoleColor.DarkYellow},
    };

    private CellType[] walkableCellTypes = new CellType[] { 
        CellType.Grass,
        CellType.Teleport,
        CellType.Shop,
        CellType.Rod,
    };

    public bool IsPositionWalkable(Point point)
    {
        var cellType = GetCellTypeAt(point);
        return IsCellWalkable(cellType);
    }
    public bool IsCellWalkable(CellType cellType)
    {
        return walkableCellTypes.Contains(cellType);
    }
    

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

        int columnCount = mapData.Length;
        int rowCount = 0;

        foreach (int[] row in mapData)
        {
            if (row.Length > rowCount)
            {
                rowCount = row.Length;
            }
        }

        Size = new Point(rowCount, columnCount);
        Origin = new Point(0, 0);

        AddTeleportsPairCoords(new Point(6, 10), new Point(11,10));
    }

    private void AddTeleportsPairCoords(Point teleport1, Point teleport2)
    {
        _teleports.Add(teleport1, teleport2);
        _teleports.Add(teleport2, teleport1);
    }

    public bool IsTeleport(Point point)
    {
        return _teleports.ContainsKey(point);
    }

    public Point GetTeleportDestination(Point origin)
    {
        var teleportExists = _teleports.TryGetValue(origin, out var destination);
        if (teleportExists)
        {
            return destination;
        }

        throw new Exception($"Position {origin.X}, {origin.Y} is not valid teleport");
    }

    public CellType GetCellTypeAt(Point point)
    {
        return GetCellTypeAt(point.X, point.Y);
    }

    private CellType GetCellTypeAt(int x, int y)
    {
        return (CellType)mapData[y][x];
    }

    public char GetCellVisualAt(Point point)
    {
        return cellVisuals[GetCellTypeAt(point)];
    }

    public bool IsWater(Point point)
    {
        return GetCellTypeAt(point.X, point.Y) == CellType.Water;
    }

    public bool IsShop(Point point)
    {
        return GetCellTypeAt(point.X, point.Y) == CellType.Shop;
    }

    public void Display(Point origin)
    {
        Origin = origin;
        Console.CursorTop = origin.Y;
        for (int row = 0; row < mapData.Length; row++)
        {
            DrawRow(row, origin.X);
            Console.WriteLine();
        }
    }

    private ConsoleColor GetCellColor(CellType cellType)
    {
        return colorMap[cellType];
    }

    private char GetCellVisual(CellType cellType)
    {
        return cellVisuals[cellType];
    }


    internal bool IsPointCorrect(Point point)
    {
        if (point.Y >= 0 && point.Y < mapData.Length)
        {
            if (point.X >= 0 && point.X < mapData[point.Y].Length)
            {
                if (walkableCellTypes.Contains(GetCellTypeAt(point)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void DrawRow(int row, int cursorLeft)
    {
        Console.CursorLeft = cursorLeft;
        for (int column = 0; column < mapData[row].Length; column++)
        {
            var cellType = GetCellTypeAt(column, row);
            var cellVisual = GetCellVisual(cellType);
            var cellColor = GetCellColor(cellType);
            Console.ForegroundColor = cellColor;
            Console.Write(cellVisual);
            Console.ResetColor();
        }
    }
};
