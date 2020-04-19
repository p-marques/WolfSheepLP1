using System;
using System.Collections.Generic;
using System.Text;


namespace WolfSheepGameLP1
{
	public class BoardSquare
	{
		public Coord Pos { get; private set; }

		public Piece Piece { get; private set; } = null;

		public bool IsPlayable { get; private set; }

		public BoardSquare(int columnIndex, int rowIndex)
		{
			Pos = new Coord(columnIndex, rowIndex);

			IsPlayable = rowIndex % 2 != 0 && columnIndex % 2 == 0 || columnIndex % 2 != 0 && rowIndex % 2 == 0;
		}

		/// <summary>
		/// Place a game piece in this square.
		/// </summary>
		/// <param name="piece">The game piece to place.</param>
		public void PutPiece(Piece piece)
        {
			// If this piece is already on the board...
			if (piece.BoardSquare != null)
			{
				// ...remove it from it's current location.
				piece.BoardSquare.Piece = null;
			}

			this.Piece = piece;

			piece.SetBoardSquareReference(this);
        }
	}
}
