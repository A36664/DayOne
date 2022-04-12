using board;

namespace chessGame
{
    class Knight : ChessPiece
    {
        public Knight(ChessBoard board, Colour colour)
            : base(board, colour) { }

        public override string ToString()
        {
            return "H";
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

            position.DefineValues(PiecePosition.Y - 1, PiecePosition.X - 2);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
            }

            position.DefineValues(PiecePosition.Y - 2, PiecePosition.X - 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
            }

            position.DefineValues(PiecePosition.Y - 2, PiecePosition.X + 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
            }

            position.DefineValues(PiecePosition.Y - 1, PiecePosition.X + 2);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
            }

            position.DefineValues(PiecePosition.Y + 1, PiecePosition.X + 2);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
            }

            position.DefineValues(PiecePosition.Y + 2, PiecePosition.X + 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
            }

            position.DefineValues(PiecePosition.Y + 2, PiecePosition.X - 1);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
            }

            position.DefineValues(PiecePosition.Y + 1, PiecePosition.X - 2);
            if (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
            }

            return boolboard;
        }
    }
}
