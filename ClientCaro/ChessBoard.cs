
using System.Drawing;

namespace ClientCaro
{
    public class ChessBoard
    {
        public int RowNum { get; set; }
        public int ColNum { get; set; }

        public ChessBoard() : this(20, 20) { }
        public ChessBoard(int rowNum, int colNum)
        {
            RowNum = rowNum;
            ColNum = colNum;
        }
        public void PaintBoard(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            int w = ChessCell.CellWidth;
            int h = ChessCell.CellHeight;

            for (int i = 0; i <= ColNum; i++)
                graphics.DrawLine(pen, i * w, 0, i * w, RowNum * h);
            for (int i = 0; i <= RowNum; i++)
                graphics.DrawLine(pen, 0, i * h, RowNum * w, i * w);
        }
        public void CellX(Graphics graphics, Point point, SolidBrush soildB)
        {
            Font font = new Font(new FontFamily("Microsoft Sans Serif"), 15, FontStyle.Bold);
            graphics.DrawString("X", font, soildB, new Point(point.X + 2, point.Y + 2));
        }

        public void CellO(Graphics graphics, Point point, SolidBrush soildB)
        {
            Font font = new Font(new FontFamily("Microsoft Sans Serif"), 15, FontStyle.Bold);
            graphics.DrawString("O", font, soildB, new Point(point.X + 2, point.Y + 2));
        }
    }
}
