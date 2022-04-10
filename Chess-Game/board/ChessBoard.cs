using board.exceptions;

namespace board
{
    class ChessBoard
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private readonly ChessPiece[,] pieces;

        public ChessBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new ChessPiece[rows, columns];
        }

        public ChessPiece Piece (int row, int column)
        {
            return pieces[row, column];
        }

        public ChessPiece Piece(Position position)
        {
            return pieces[position.X, position.Y];
        }

        public bool IfThereIsAPiece(Position position)
        {
            ValidPosition(position);
            return Piece(position) != null;
        } 

        public void SetPiece(ChessPiece newPiece, Position newPosition)
        {
            if (IfThereIsAPiece(newPosition))
            {
                throw new BoardException("The position is already occupied by a piece.");
            }
            pieces[newPosition.X, newPosition.Y] = newPiece;
            newPiece.PiecePosition = newPosition;
        }

        public ChessPiece GetPiece(Position position)
        {
            if(Piece(position) == null)
            {
                return null;
            }
            ChessPiece newPiece = Piece(position);
            newPiece.PiecePosition = null;
            pieces[position.X, position.Y] = null;
            return newPiece;
        }

        public bool IfValidPosition(Position position)
        {
            if(position.X < 0 || position.X >= Rows || position.Y < 0 || position.Y >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidPosition(Position position)
        {
            if (!IfValidPosition(position))
            {
                throw new BoardException("Position Invalid.");
            }
        }
    }
}
