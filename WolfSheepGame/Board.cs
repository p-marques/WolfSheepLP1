using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
	public class Board
	{
		public uint Size { get; private set; }

		public BoardRow[] Rows { get; private set; }

		public Board(uint size)
		{
			this.Size = size;
			CreateRows();
		}

		public void CreateRows()
		{
			this.Rows = new BoardRow[Size];
			for (int i = 0; i < Size; i++)
			{
				this.Rows[i] = new BoardRow(i, Size);
			}
		}


		public bool IsSquareAvailable(Piece piece, Coord Pos, Coord destination)
        {
			bool result = false;

			if(piece.Unicode.Equals("S"))
			{
				if((0 <= destination.Column && destination.Column < Size) && (0 <= destination.Row && destination.Row < Size) && ((destination.Column == Pos.Column - 1 ) || (destination.Row == Pos.Row - 1) || (destination.Row == Pos.Row + 1) ) )
				{
					result = Rows[destination.Row].Squares[destination.Column].Piece == null;
				}
			}
			else if (piece.Unicode.Equals("W"))
			{
				if ((0 <= destination.Column && destination.Column < Size) && (0 <= destination.Row && destination.Row < Size) && ((destination.Column == Pos.Column - 1) || (destination.Column == Pos.Column + 1) || (destination.Row == Pos.Row - 1) || (destination.Row == Pos.Row + 1)))
				{
					result = Rows[destination.Row].Squares[destination.Column].Piece == null;
				}
			}

			return result;
        }

		public void Move(Piece piece, Coord destination)
		{
			piece.BoardSquare.Piece = null;

			piece.BoardSquare = Rows[destination.Row].Squares[destination.Column];

			piece.BoardSquare.Piece = piece;
		}
	}
}
