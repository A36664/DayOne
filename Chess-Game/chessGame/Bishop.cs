using board;
using Chess.chessGame.rules;

namespace chessGame
{
    class Bishop : ChessPiece,ICrossRule
    {
        public Bishop(ChessBoard board, Colour colour)
            : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Position position)
        {
            ChessPiece piece = Board.Piece(position);
            return piece == null || piece.Colour != Colour;
        }

        public override bool[,] checkMove()
        {
            bool[,] boolboard = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);
            CrossUpLeftAndDownRight(ref boolboard, ref position);
            CrossUpRightAndDownLeft(ref boolboard, ref position);

            return boolboard;
        }

        public void CrossUpRightAndDownLeft(ref bool[,] boolboard, ref Position position)
        {
            
            position.DefineValues(PiecePosition.Y - 1, PiecePosition.X - 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.DefineValues(position.Y - 1, position.X - 1);
            }

            position.DefineValues(PiecePosition.Y + 1, PiecePosition.X + 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.DefineValues(position.Y + 1, position.X + 1);
            }
        }

        public void CrossUpLeftAndDownRight(ref bool[,] boolboard, ref Position position)
        {

            position.DefineValues(PiecePosition.Y + 1, PiecePosition.X - 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.DefineValues(position.Y + 1, position.X - 1);
            }

            position.DefineValues(PiecePosition.Y - 1, PiecePosition.X + 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.DefineValues(position.Y - 1, position.X + 1);
            }
        }
    }
}
