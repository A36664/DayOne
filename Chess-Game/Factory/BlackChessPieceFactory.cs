using board;
using chessGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Factory
{
    class BlackChessPieceFactory : AbstractChessPieceFactory
    {
        public override ChessPiece CreateChessPiece(string type,ChessBoard board,ChessTurns chessTurns=null)
        {


            switch (type)
            {
                case "King":
                    return new King(board, Colour.black, chessTurns);
                case "Queen":
                    return new Queen(board,Colour.black);
                case "Knight":
                    return new Knight(board,Colour.black);
                case "Bishop":
                    return new Bishop(board, Colour.black);
                case "Rook":
                    return new Rook(board, Colour.black);
                case "Pawn":
                    return new Pawn(board,Colour.black, chessTurns);
            }

            throw new NotImplementedException();
        }
    }

    
}
