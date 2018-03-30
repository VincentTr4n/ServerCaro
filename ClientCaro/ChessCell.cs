
using System.Drawing;

namespace ClientCaro
{
    public class ChessCell
    {
        public static int CellWidth = 25;
        public static int CellHeight = 25;

        public int CellRow { get; set; }
        public int CellCol { get; set; }
        public Point CellLocal { get; set; }
        public int Parent { get; set; }
        public ChessCell() { }
        public ChessCell(int row,int col,Point local,int parent)
        {
            CellCol = col;
            CellRow = row;
            CellLocal = local;
            Parent = parent;
        }
    }
}
