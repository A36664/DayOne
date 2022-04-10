using board;
using Chess.chessGame.rules;

namespace chessGame
{
    class King : ChessPiece, IRule
    {
        private ChessTurns ChessTurns;
        public King(ChessBoard board, Colour colour, ChessTurns chessTurns)
            : base(board, colour)
        {
            ChessTurns = chessTurns;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position position)
        {
            ChessPiece piece = Board.Piece(position);
            return piece == null || piece.Colour != Colour;
        }

        private bool RookTestForCastling(Position position)
        {
            ChessPiece piece = Board.Piece(position);
            return piece != null && piece is Rook && piece.Colour == Colour && piece.MovementsQuantity == 0;
        }

        public override bool[,] checkMove()
        {
            bool[,] boolboard = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            HorizontalMove(ref boolboard, ref position);
            VerticalMove(ref boolboard, ref position);
            CrossUpLeftAndDownRight(ref boolboard, ref position);
            CrossUpRightAndDownLeft(ref boolboard, ref position);

            // Special play Castling
            if (MovementsQuantity == 0 && !ChessTurns.Xeque)
            {
                // #Small castling
                Position rookSmallCastling = new Position(PiecePosition.X, PiecePosition.Y + 3);
                if (RookTestForCastling(rookSmallCastling))
                {
                    Position kingPosition1 = new Position(PiecePosition.X, PiecePosition.Y + 1);
                    Position kingPosition2 = new Position(PiecePosition.X, PiecePosition.Y + 2);
                    if (Board.Piece(kingPosition1) == null && Board.Piece(kingPosition2) == null)
                    {
                        boolboard[PiecePosition.X, PiecePosition.Y + 2] = true;
                    }
                }

                // #Big castling
                Position rookBigCastling = new Position(PiecePosition.X, PiecePosition.Y - 4);
                if (RookTestForCastling(rookBigCastling))
                {
                    Position kingPosition1 = new Position(PiecePosition.X, PiecePosition.Y - 1);
                    Position kingPosition2 = new Position(PiecePosition.X, PiecePosition.Y - 2);
                    Position kingPosition3 = new Position(PiecePosition.X, PiecePosition.Y - 3);
                    if (Board.Piece(kingPosition1) == null && Board.Piece(kingPosition2) == null && Board.Piece(kingPosition3) == null)
                    {
                        boolboard[PiecePosition.X, PiecePosition.Y - 2] = true;
                    }
                }
            }

            return boolboard;
        }

        public void HorizontalMove(ref bool[,] boolboard, ref Position position)
        {
            // sang trái
            position.DefineValues(PiecePosition.X - 1, PiecePosition.Y);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.X, position.Y] = true;
            }

            // sang phải
            position.DefineValues(PiecePosition.X + 1, PiecePosition.Y);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.X, position.Y] = true;
            }
        }

        public void VerticalMove(ref bool[,] boolboard, ref Position position)
        {
            // lên trên
            position.DefineValues(PiecePosition.X, PiecePosition.Y + 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.X, position.Y] = true;
            }

            // đi xuống
            position.DefineValues(PiecePosition.X, PiecePosition.Y - 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.X, position.Y] = true;
            }
        }

        public void CrossUpRightAndDownLeft(ref bool[,] boolboard, ref Position position)
        {
            // chéo trên phải
            position.DefineValues(PiecePosition.X + 1, PiecePosition.Y + 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.X, position.Y] = true;
            }

            // chéo dưới trái
            position.DefineValues(PiecePosition.X - 1, PiecePosition.Y - 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.X, position.Y] = true;
            }
        }

        public void CrossUpLeftAndDownRight(ref bool[,] boolboard, ref Position position)
        {
            // chéo trên trái
            position.DefineValues(PiecePosition.X - 1, PiecePosition.Y + 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.X, position.Y] = true;
            }

            // chéo dưới phải
            position.DefineValues(PiecePosition.X + 1, PiecePosition.Y - 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.X, position.Y] = true;
            }
        }
    }
}
