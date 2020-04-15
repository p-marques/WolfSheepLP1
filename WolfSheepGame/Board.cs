using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSheepGameLP1
{
	public class Board
	{
		public uint Size { get; private set; }

		public BRow[] Rows { get; private set; }

		public Board(uint size)
		{
			this.Size = size;
			CreateRows();
		}

		public void CreateRows()
		{
			this.Rows = new BRow(Size);
			for (int i = 0; i < Size; i++)
			{
				this.Rows[i] = new BRow(i, Size);
			}
		}

		public void SetupTable(SheepPlayer sheepPlayer, WoolfPlayer woolfPlayer)
		{
			this.Rows[0].Squares[1].PlacePiece(wolfPlayer.WolfPiece);

			for (int i = 0, j = 0; i < Rows.Length; i += 2, j++)
			{
				this.Rows[Size - 1].Squares[i].PlacePiece(sheepPlayer.SheepPieces[j]);
			}
		}

		public bool IsSquareAvailable(Coord Pos)
        {
			bool result = false;

			if((0 <= position.Column && position.Column < Size) && (0 <= position.Row && position.row < Size))
            {

            }
        }
	}
}
