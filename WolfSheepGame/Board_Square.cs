﻿using System;
using System.Collections.Generic;
using System.Text;


namespace WolfSheepGameLP1
{
	public class BoardSquare
	{
		public Axis Pos { get; private set; }

		public Piece Piece { get; set; } = null;

		public bool Playable { get; private set; }

		public void Square(int columnIndex, int rowIndex)
        {
			Pos = new Axis(columnIndex, rowIndex);

			Playable = rowIndex % 2 != 0 && columnIndex % 2 == 0 || columnIndex % 2 != 0 && rowIndex % 2 == 0;
		}

		public void PutPiece(Piece piece)
        {
			this.Piece = piece;

			piece.BoardSquare = this;
        }
	}
}
