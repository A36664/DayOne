using board;
using chessGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Factory
{
    abstract class AbstractChessPieceFactory : IChessPieceFactory
    {
        public abstract ChessPiece CreateChessPiece(string type, ChessBoard board, ChessTurns chessTurns = null);
    }
}
