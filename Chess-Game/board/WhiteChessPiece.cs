using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.board
{
    abstract class WhiteChessPiece : ChessPiece
    {
        protected WhiteChessPiece(ChessBoard board, Colour colour) : base(board, colour)
        {
        }
    }
}
