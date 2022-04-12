using board;
using Chess.chessGame.rules;

namespace chessGame
{
    class Pawn : ChessPiece,IRule
    {
        private ChessTurns ChessTurns;
        public Pawn(ChessBoard board, Colour colour, ChessTurns chessTurns)
            : base(board, colour) 
        {
            ChessTurns = chessTurns;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool SpotEnemy(Position position)
        {
            ChessPiece piece = Board.Piece(position);
            return piece != null && piece.Colour != Colour;
        }

        private bool IsFree(Position position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] checkMove()
        {
            bool[,] boolboard = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            if (Colour == Colour.white)
            {
                // 
                position.DefineValues(PiecePosition.Y - 1, PiecePosition.X);
                if (Board.IfValidPosition(position) && IsFree(position)){
                    boolboard[position.Y, position.X] = true;
                }

                position.DefineValues(PiecePosition.Y - 2, PiecePosition.X);
                Position position1 = new Position(PiecePosition.Y - 1, PiecePosition.X);
                if (Board.IfValidPosition(position1) && IsFree(position1) && Board.IfValidPosition(position) && IsFree(position) && MovementsQuantity == 0)
                {
                    boolboard[position.Y, position.X] = true;
                }

              
                position.DefineValues(PiecePosition.Y - 1, PiecePosition.X - 1);
                if (Board.IfValidPosition(position) && SpotEnemy(position))
                {
                    boolboard[position.Y, position.X] = true;
                }
              
                position.DefineValues(PiecePosition.Y - 1, PiecePosition.X + 1);
                if (Board.IfValidPosition(position) && SpotEnemy(position))
                {
                    boolboard[position.Y, position.X] = true;
                }
                // check end
                if (PiecePosition.Y == 3)
                {
                    Position left = new Position(PiecePosition.Y, PiecePosition.X - 1);
                    if (Board.IfValidPosition(left) && SpotEnemy(left) && Board.Piece(left) == ChessTurns.EnPassant)
                    {
                        boolboard[left.Y - 1, left.X] = true;
                    }
                    Position right = new Position(PiecePosition.Y, PiecePosition.X + 1);
                    if (Board.IfValidPosition(right) && SpotEnemy(right) && Board.Piece(right) == ChessTurns.EnPassant)
                    {
                        boolboard[right.Y - 1, right.X] = true;
                    }
                }
            }
            else
            {
                position.DefineValues(PiecePosition.Y + 1, PiecePosition.X);
                if (Board.IfValidPosition(position) && IsFree(position))
                {
                    boolboard[position.Y, position.X] = true;
                }

                position.DefineValues(PiecePosition.Y + 2, PiecePosition.X);
                Position position1 = new Position(PiecePosition.Y + 1, PiecePosition.X);
                if (Board.IfValidPosition(position1) && IsFree(position1) && Board.IfValidPosition(position) && IsFree(position) && MovementsQuantity == 0)
                {
                    boolboard[position.Y, position.X] = true;
                }

                position.DefineValues(PiecePosition.Y + 1, PiecePosition.X + 1);
                if (Board.IfValidPosition(position) && SpotEnemy(position))
                {
                    boolboard[position.Y, position.X] = true;
                }

                position.DefineValues(PiecePosition.Y + 1, PiecePosition.X - 1);
                if (Board.IfValidPosition(position) && SpotEnemy(position))
                {
                    boolboard[position.Y, position.X] = true;
                }

                // check end
                if (PiecePosition.Y == 4)
                {
                    Position left = new Position(PiecePosition.Y, PiecePosition.X - 1);
                    if (Board.IfValidPosition(left) && SpotEnemy(left) && Board.Piece(left) == ChessTurns.EnPassant)
                    {
                        boolboard[left.Y + 1, left.X] = true;
                    }
                    Position right = new Position(PiecePosition.Y, PiecePosition.X + 1);
                    if (Board.IfValidPosition(right) && SpotEnemy(right) && Board.Piece(right) == ChessTurns.EnPassant)
                    {
                        boolboard[right.Y + 1, right.X] = true;
                    }
                }
            }

            return boolboard;
        }

        public void HorizontalMove(ref bool[,] boolboard, ref Position position)
        {
            throw new System.NotImplementedException();
        }

        public void VerticalMove(ref bool[,] boolboard, ref Position position)
        {
            throw new System.NotImplementedException();
        }

        public void CrossUpRightAndDownLeft(ref bool[,] boolboard, ref Position position)
        {
            throw new System.NotImplementedException();
        }

        public void CrossUpLeftAndDownRight(ref bool[,] boolboard, ref Position position)
        {
            throw new System.NotImplementedException();
        }
    }
}
