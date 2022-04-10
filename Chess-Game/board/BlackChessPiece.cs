using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.board
{
    abstract class BlackChessPiece : ChessPiece
    {
        protected BlackChessPiece(ChessBoard board, Colour colour) : base(board, colour)
        {
        }
    }
}
