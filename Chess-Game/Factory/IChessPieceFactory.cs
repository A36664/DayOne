using board;
using chessGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Factory
{
    interface IChessPieceFactory
    {
        ChessPiece CreateChessPiece(string type, ChessBoard board, ChessTurns chessTurns = null);
    }
}
