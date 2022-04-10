using board;
using chessGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Factory
{
    class WhiteChessPieceFactory : AbstractChessPieceFactory
    {
        public override ChessPiece CreateChessPiece(string type, ChessBoard board, ChessTurns chessTurns = null)
        {
            switch (type)
            {
                case "King":
                    return new King(board, Colour.white, chessTurns);
                case "Queen":
                    return new Queen(board, Colour.white);
                case "Knight":
                    return new Knight(board, Colour.white);
                case "Bishop":
                    return new Bishop(board, Colour.white);
                case "Rook":
                    return new Rook(board, Colour.white);
                case "Pawn":
                    return new Pawn(board, Colour.white, chessTurns);
            }

            throw new NotImplementedException();
        }
    }
}
