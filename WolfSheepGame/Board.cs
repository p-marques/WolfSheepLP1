using System;
using System.Collections.Generic;
using System.Text;
using WolfSheepGame;

namespace WolfSheepGameLP1
{
	public class Board
	{
		public uint Size { get; private set; }

		public BoardRow[] Rows { get; private set; }

		//creates a board with the array of rows
		public Board(uint size)
		{
			this.Size = size;
			CreateRows();
		}

		//creates and array with Sizes rows
		public void CreateRows()
		{
			this.Rows = new BoardRow[Size];
			for (int i = 0; i < Size; i++)
			{
				this.Rows[i] = new BoardRow(i, Size);
			}
		}

		//verifys if the square is empty or not
		public bool IsSquareAvailable(Coord Pos)
        {
			bool result = false;

			if((0 <= Pos.Column && Pos.Column < Size) )
			{
				//if there isn't any piece in the possition Pos the function returns true
				result = Rows[Pos.Row].Squares[Pos.Column].Piece == null;
			}

			return result;
        }

		//transfers a piece to a place with the coordinates destination
		public void Move(Piece piece, Coord destination)
		{
			piece.BoardSquare.Piece = null;

			piece.BoardSquare = Rows[destination.Row].Squares[destination.Column];

			piece.BoardSquare.Piece = piece;
		}

		//sets the inicial table putting the wolf piece in the meadle in the top and in the bottom the four sheeps
		public void SetStartingdTable(WolfPlayer wolfPlayer, SheepPlayer sheepPlayer)
		{
			this.Rows[0].Squares[1].PutPiece(wolfPlayer.WolfPiece);

			for (int i = 0, j = 0; i < Rows.Length; i += 2, j++)
			{
				this.Rows[Size - 1].Squares[i].PutPiece(sheepPlayer.SheepPieces[j]);
			}
		}
	}
}
