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

		/// <summary>
		/// Places the pieces in their starting positions.
		/// </summary>
		/// <param name="sheepPlayer">The Sheep Player.</param>
		public void SetupGamePieces(SheepPlayer sheepPlayer)
		{
			for (int i = 0, j = 0; i < Rows.Length; i += 2, j++)
			{
				this.Rows[Size - 1].Squares[i].PutPiece(sheepPlayer.Pieces[j]);
			}
		}

		/// <summary>
		/// Moves a piece in a desired direction.
		/// </summary>
		/// <param name="piece">The piece to be moved.</param>
		/// <param name="destinationSquare">The destination square.</param>
		/// <returns>A boolean representing the success of the move.</returns>
		public bool MovePiece(Piece piece, BoardSquare destinationSquare)
		{
			bool result;

			result = GetIsSquareAvailable(destinationSquare);

			if (result)
			{
				destinationSquare.PutPiece(piece);
			}
			
			return result;
		}

		/// <summary>
		/// Get the square in a given direction in relation to a game piece.
		/// Returns NULL if no square exists in that position.
		/// </summary>
		/// <param name="piece">The game's piece to use.</param>
		/// <param name="direction">The direction in relation to the game's piece.</param>
		/// <returns>The square in that position. NULL if no square exists.</returns>
		public BoardSquare GetBoardSquareByDirection(Piece piece, Direction direction)
		{
			Coord pos;
			BoardSquare square = null;

			pos = GetNewCoordinates(piece, direction);

			if (GetIsPositionValid(pos))
			{
				square = Rows[pos.Row].Squares[pos.Column];
			}

			return square;
		}

		/// <summary>
		/// Checks if a given player has any possible moves.
		/// </summary>
		/// <param name="player">The player to check for possible moves.</param>
		/// <returns>A boolean value representing availability of moves.</returns>
		public bool GetPlayerHasPossibleMoves(Player player)
		{
			bool result = false;

			if (player is WolfPlayer wolfPlayer)
			{
				result = GetPieceHasPossibleMoves(wolfPlayer, wolfPlayer.Piece);
			}
			else
			{
				SheepPlayer sheepPlayer = (SheepPlayer)player;

				for (int i = 0; i < sheepPlayer.Pieces.Length; i++)
				{
					result = GetPieceHasPossibleMoves(sheepPlayer, sheepPlayer.Pieces[i]);
				}

			}

			return result;
		}

		/// <summary>
		/// Checks if the Wolf player has won the game by reaching the
		/// original row of the sheep pieces.
		/// </summary>
		/// <param name="wolfPlayer">The Wolf player.</param>
		/// <returns>A boolean value representing if the wolf player has won.</returns>
		public bool GetHasWolfPlayerWon(WolfPlayer wolfPlayer)
		{
			return wolfPlayer.Piece.BoardSquare.Pos.Row == Size - 1;
		}

		/// <summary>
		/// Checks if a given piece has any possible moves,
		/// </summary>
		/// <param name="player">The player to witch the piece belongs to.</param>
		/// <param name="piece">The piece to check for possible moves.</param>
		/// <returns>A boolean value representing if available moves are present.</returns>
		public bool GetPieceHasPossibleMoves(Player player, Piece piece)
		{
			BoardSquare holderSquare;
			bool result = false;

			for (int i = 0; i < player.AllowedMoveDirections.Length; i++)
			{
				holderSquare = GetBoardSquareByDirection(piece, player.AllowedMoveDirections[i]);

				if (holderSquare != null)
				{
					result = GetIsSquareAvailable(holderSquare);

					if (result)
					{
						break;
					}
				}
			}

			return result;
		}

		/// <summary>
		/// Checks to see if square is available to receive a game piece.
		/// </summary>
		/// <param name="square">The square to check.</param>
		/// <returns>A boolean value representing if the square is available.</returns>
		private bool GetIsSquareAvailable(BoardSquare square)
		{
			return square.Piece == null;
		}

		/// <summary>
		/// Checks if a given position is inside the game's board.
		/// </summary>
		/// <param name="pos">The position to check.</param>
		/// <returns>A boolean value representing the validity of the position given.</returns>
		private bool GetIsPositionValid(Coord pos)
		{
			return pos.Column >= 0 && pos.Row >= 0 && pos.Column < Size && pos.Row < Size;
		}

		/// <summary>
		/// Calculates the future position of the player's piece if the move goes through.
		/// </summary>
		/// <param name="piece">The player's piece looking to move.</param>
		/// <param name="direction">The direction in witch the piece desires to move.</param>
		/// <returns>A <see cref="Coord"/> object detailing the future position.</returns>
		private Coord GetNewCoordinates(Piece piece, Direction direction)
		{
			int rowDelta = 0, columnDelta = 0;
			Coord oldCoords = piece.BoardSquare.Pos;

			switch (direction)
			{
				case Direction.Left:
					columnDelta = -2;
					break;
				case Direction.Right:
					columnDelta = 2;
					break;
				case Direction.TopRight:
					rowDelta = -1;
					columnDelta = 1;
					break;
				case Direction.TopLeft:
					rowDelta = -1;
					columnDelta = -1;
					break;
				case Direction.BottomRight:
					rowDelta = 1;
					columnDelta = 1;
					break;
				case Direction.BottomLeft:
					rowDelta = 1;
					columnDelta = -1;
					break;
			}

			return new Coord(oldCoords.Column + columnDelta, oldCoords.Row + rowDelta);
		}
	}
}
