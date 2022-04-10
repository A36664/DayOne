using Chess.board;
using Chess.chessGame.rules;

namespace board
{
    abstract class ChessPiece: IChessPiece
    {
        public Position PiecePosition { get; set; }
        public Colour Colour { get; protected set; }
        public int MovementsQuantity { get; protected set; }
        public ChessBoard Board { get; set; }

        public ChessPiece(ChessBoard board, Colour colour)
        {
            PiecePosition = null;
            Board = board;
            Colour = colour;
            MovementsQuantity = 0;
        }

        public void AddMovements()
        {
            MovementsQuantity++;
        }

        public void UnAddMovements()
        {
            MovementsQuantity--;
        }

        public bool PossibleMovementsAvailable()
        {
            bool[,] move = checkMove();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (move[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool checkMoveTo(Position position)
        {
            return checkMove()[position.X, position.Y];
        }

        public abstract bool[,] checkMove();

       
    }
}
