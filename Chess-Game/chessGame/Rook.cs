using board;
using Chess.chessGame.rules;

namespace chessGame
{
    class Rook : ChessPiece, IHoVeRule
    {
        public Rook(ChessBoard board, Colour colour)
            : base(board, colour) { }

        public override string ToString()
        {
            return "R";
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



            HorizontalMove(ref boolboard, ref position);
            VerticalMove(ref boolboard, ref position);




            return boolboard;
        }

        public void HorizontalMove(ref bool[,] boolboard, ref Position position)
        {
            position.DefineValues(PiecePosition.X - 1, PiecePosition.Y);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.X, position.Y] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.X -= 1;
            }


            position.DefineValues(PiecePosition.X + 1, PiecePosition.Y);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.X, position.Y] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.X += 1;
            }
        }

        public void VerticalMove(ref bool[,] boolboard, ref Position position)
        {
            position.DefineValues(PiecePosition.X, PiecePosition.Y + 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.X, position.Y] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.Y += 1;
            }

            position.DefineValues(PiecePosition.X, PiecePosition.Y - 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.X, position.Y] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.Y -= 1;
            }
        }


    }
}
