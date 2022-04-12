using board;
using Chess.chessGame.rules;

namespace chessGame
{
    class Queen : ChessPiece, IRule
    {
        public Queen(ChessBoard board, Colour colour)
            : base(board, colour) { }

        public override string ToString()
        {
            return "Q";
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
            CrossUpRightAndDownLeft(ref boolboard, ref position);
            CrossUpLeftAndDownRight(ref boolboard, ref position);

            return boolboard;
        }

        public void HorizontalMove(ref bool[,] boolboard, ref Position position)
        {

            // sang trái
            position.DefineValues(PiecePosition.Y - 1, PiecePosition.X);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.Y -= 1;
            }
            // sang phải
            position.DefineValues(PiecePosition.Y + 1, PiecePosition.X);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.Y += 1;
            }
        }

        public void VerticalMove(ref bool[,] boolboard, ref Position position)
        {
            // lên trên
            position.DefineValues(PiecePosition.Y, PiecePosition.X + 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.X += 1;
            }


            // xuống dưới
            position.DefineValues(PiecePosition.Y, PiecePosition.X - 1);
            while (Board.IfValidPosition(position) && CanMove(position))
            {
                boolboard[position.Y, position.X] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Colour != Colour)
                {
                    break;
                }
                position.X -= 1;
            }
        }

        public void CrossUpRightAndDownLeft(ref bool[,] boolboard, ref Position position)
        {
            // chéo trên phải
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


            // chéo dưới trái
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
        }

        public void CrossUpLeftAndDownRight(ref bool[,] boolboard, ref Position position)
        {
            // chéo trên trái
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

            // chéo dưới phải
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
        }
    }
}
