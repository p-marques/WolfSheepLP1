using System;
using System.Collections.Generic;
using System.Text;


namespace WolfSheepGameLP1
{
	public class BoardSquare
	{
		public Coord Pos { get; private set; }

		public Piece Piece { get; set; } = null;

		public bool IsPlayable { get; private set; }

		public BoardSquare(int columnIndex, int rowIndex)
		{
			Pos = new Coord(columnIndex, rowIndex);

			IsPlayable = rowIndex % 2 != 0 && columnIndex % 2 == 0 || columnIndex % 2 != 0 && rowIndex % 2 == 0;
		}

		public void PutPiece(Piece piece)
        {
			this.Piece = piece;

			piece.BoardSquare = this;
        }
	}
}
