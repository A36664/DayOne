using board;
using board.exceptions;
using Chess.chessGame;
using Chess.Factory;
using System.Collections.Generic;

namespace chessGame
{
    class ChessTurns
    {
        public ChessBoard Board { get; private set; }
        public int Turn { get; private set; }
        public Colour PlayerTurn { get;  set; }
        public bool GameOver { get; private set; }
        private HashSet<ChessPiece> Pieces;
        private HashSet<ChessPiece> Captured;
        public bool Xeque { get; private set; }
        public ChessPiece EnPassant { get; private set; }

        private IChessPieceFactory _factory;
        public ChessTurns()
        {
            Board = new ChessBoard(8, 8);
            Turn = 1;
            //PlayerTurn = Colour.white;
            GameOver = false;
            Xeque = false;
            EnPassant = null;
            Pieces = new HashSet<ChessPiece>();
            Captured = new HashSet<ChessPiece>();
            PutPieces();
        }

        public ChessPiece MovePiece(Position origin, Position destination)
        {
            ChessPiece piece = Board.GetPiece(origin);
            piece.AddMovements();
            ChessPiece pieceCaptured = Board.GetPiece(destination);
            Board.SetPiece(piece, destination);
            if (pieceCaptured != null)
            {
                Captured.Add(pieceCaptured);
            }

            // # castling right
            if (piece is King && destination.X == origin.X + 2)
            {
                Position RookOriginPosition = new Position(origin.Y, origin.X + 3);
                Position RookDestinationPosition = new Position(origin.Y, origin.X + 1);
                ChessPiece rook = Board.GetPiece(RookOriginPosition);
                rook.AddMovements();
                Board.SetPiece(rook, RookDestinationPosition);
            }

            // # castling left
            if (piece is King && destination.X == origin.X - 2)
            {
                Position RookOriginPosition = new Position(origin.Y, origin.X - 4);
                Position RookDestinationPosition = new Position(origin.Y, origin.X - 1);
                ChessPiece rook = Board.GetPiece(RookOriginPosition);
                rook.AddMovements();
                Board.SetPiece(rook, RookDestinationPosition);
            }

            // #En passant
            if (piece is Pawn)
            {
                if (origin.X != destination.X && pieceCaptured == null)
                {
                    Position pawnPosition;
                    if (piece.Colour == Colour.white)
                    {
                        pawnPosition = new Position(destination.Y + 1, destination.X);
                    }
                    else
                    {
                        pawnPosition = new Position(destination.Y - 1, destination.X);
                    }
                    pieceCaptured = Board.GetPiece(pawnPosition);
                    Captured.Add(pieceCaptured);
                }
            }

            return pieceCaptured;
        }

        public void UnmakeMovement(Position origin, Position destination, ChessPiece pieceCaptured)
        {
            ChessPiece piece = Board.GetPiece(destination);
            piece.UnAddMovements();
            if (pieceCaptured != null)
            {
                Board.SetPiece(pieceCaptured, destination);
                Captured.Remove(pieceCaptured);
            }
            Board.SetPiece(piece, origin);

            // #Small castling
            if (piece is King && destination.X == origin.X + 2)
            {
                Position RookOriginPosition = new Position(origin.Y, origin.X + 3);
                Position RookDestinationPosition = new Position(origin.Y, origin.X + 1);
                ChessPiece rook = Board.GetPiece(RookDestinationPosition);
                rook.UnAddMovements();
                Board.SetPiece(rook, RookOriginPosition);
            }

            // #Big castling
            if (piece is King && destination.X == origin.X - 2)
            {
                Position RookOriginPosition = new Position(origin.Y, origin.X - 4);
                Position RookDestinationPosition = new Position(origin.Y, origin.X - 1);
                ChessPiece rook = Board.GetPiece(RookDestinationPosition);
                rook.UnAddMovements();
                Board.SetPiece(rook, RookOriginPosition);
            }

            // #En passant
            if (piece is Pawn)
            {
                if (origin.X != destination.X && pieceCaptured == EnPassant)
                {
                    ChessPiece pawn = Board.GetPiece(destination);
                    Position pawnPosition;
                    if (piece.Colour == Colour.white)
                    {
                        pawnPosition = new Position(3, destination.X);
                    }
                    else
                    {
                        pawnPosition = new Position(4, destination.X);
                    }
                    Board.SetPiece(pawn, pawnPosition);
                }
            }
        }

        public void Play(Position origin, Position destination)
        {
            ChessPiece pieceCaptured = MovePiece(origin, destination);
            if (IsInXeque(PlayerTurn))
            {
                UnmakeMovement(origin, destination, pieceCaptured);
                throw new BoardException("You cannot execute this movement, you are in Xeque.");
            }

            ChessPiece piece = Board.Piece(destination);

            // #Promotion

            if (piece is Pawn)
            {
                if ((piece.Colour == Colour.white && destination.Y == 0) || (piece.Colour == Colour.black && destination.Y == 7))
                {
                    piece = Board.GetPiece(destination);
                    Pieces.Remove(piece);
                    ChessPiece Queen = new Queen(Board, piece.Colour);
                    Board.SetPiece(Queen, destination);
                    Pieces.Add(Queen);
                }
            }

            if (IsInXeque(Opponent(PlayerTurn)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (TestXequeMate(Opponent(PlayerTurn)))
            {
                GameOver = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

            // #En passant
            if (piece is Pawn && destination.Y == origin.Y - 2 || destination.Y == origin.Y + 2)
            {
                EnPassant = piece;
            }
        }

        public void OriginPositionValidation(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("There is no piece in the position of origin chosen.");
            }
            if (PlayerTurn != Board.Piece(position).Colour)
            {
                throw new BoardException("The piece chosen it is not yours.");
            }
            if (!Board.Piece(position).PossibleMovementsAvailable())
            {
                throw new BoardException("There is no possible moviments from the piece chosen.");
            }
        }

        public void DestinationPositionValidation(Position origin, Position destination)
        {
            if (!Board.Piece(origin).checkMoveTo(destination))
            {
                throw new BoardException("Position of destination invalid.");
            }
        }

        private void ChangePlayer()
        {
            if (PlayerTurn == Colour.white)
            {
                PlayerTurn = Colour.black;
            }
            else
            {
                PlayerTurn = Colour.white;
            }
        }

        public HashSet<ChessPiece> PiecesCaptured(Colour colour)
        {
            HashSet<ChessPiece> pieces = new HashSet<ChessPiece>();
            foreach (ChessPiece model in Captured)
            {
                if (model.Colour == colour)
                {
                    pieces.Add(model);
                }
            }
            return pieces;
        }

        public HashSet<ChessPiece> PiecesInGame(Colour colour)
        {
            HashSet<ChessPiece> pieces = new HashSet<ChessPiece>();
            foreach (ChessPiece model in Pieces)
            {
                if (model.Colour == colour)
                {
                    pieces.Add(model);
                }
            }
            pieces.ExceptWith(PiecesCaptured(colour));
            return pieces;
        }

        private Colour Opponent(Colour colour)
        {
            if (colour == Colour.white)
            {
                return Colour.black;
            }
            else
            {
                return Colour.white;
            }
        }

        private ChessPiece King(Colour colour)
        {
            foreach (ChessPiece piece in PiecesInGame(colour))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public void SetNewPiece(char column, int row, ChessPiece piece)
        {
            Board.SetPiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        public bool IsInXeque(Colour colour)
        {
            ChessPiece K = King(colour);
            if (K == null)
            {
                throw new BoardException($"There is no {colour} King in the game.");
            }
            foreach (ChessPiece piece in PiecesInGame(Opponent(colour)))
            {
                bool[,] vs = piece.checkMove();
                if (vs[K.PiecePosition.Y, K.PiecePosition.X])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestXequeMate(Colour colour)
        {
            if (!IsInXeque(colour))
            {
                return false;
            }
            foreach (ChessPiece piece in PiecesInGame(colour))
            {
                bool[,] vs = piece.checkMove();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (vs[i, j])
                        {
                            Position origin = piece.PiecePosition;
                            Position destination = new Position(i, j);
                            ChessPiece pieceCaptured = MovePiece(origin, destination);
                            bool testXeque = IsInXeque(colour);
                            UnmakeMovement(origin, destination, pieceCaptured);
                            if (!testXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        private void PutPieces()
        {
            _factory = new WhiteChessPieceFactory();
            SetNewPiece('a', 1, _factory.CreateChessPiece("Rook", Board, this));
            SetNewPiece('b', 1, _factory.CreateChessPiece("Knight", Board, this));
            SetNewPiece('c', 1, _factory.CreateChessPiece("Bishop", Board, this));
            SetNewPiece('d', 1, _factory.CreateChessPiece("Queen", Board, this));
            SetNewPiece('e', 1, _factory.CreateChessPiece("King", Board, this));
            SetNewPiece('f', 1, _factory.CreateChessPiece("Bishop", Board, this));
            SetNewPiece('g', 1, _factory.CreateChessPiece("Knight", Board, this));
            SetNewPiece('h', 1, _factory.CreateChessPiece("Rook", Board, this));
            SetNewPiece('a', 2, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('b', 2, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('c', 2, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('d', 2, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('e', 2, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('f', 2, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('g', 2, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('h', 2, _factory.CreateChessPiece("Pawn", Board, this));

            _factory = new BlackChessPieceFactory();
            SetNewPiece('a', 8, _factory.CreateChessPiece("Rook", Board, this));
            SetNewPiece('b', 8, _factory.CreateChessPiece("Knight", Board, this));
            SetNewPiece('c', 8, _factory.CreateChessPiece("Bishop", Board, this));
            SetNewPiece('d', 8, _factory.CreateChessPiece("Queen", Board, this));
            SetNewPiece('e', 8, _factory.CreateChessPiece("King", Board, this));
            SetNewPiece('f', 8, _factory.CreateChessPiece("Bishop", Board, this));
            SetNewPiece('g', 8, _factory.CreateChessPiece("Knight", Board, this));
            SetNewPiece('h', 8, _factory.CreateChessPiece("Rook", Board, this));
            SetNewPiece('a', 7, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('b', 7, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('c', 7, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('d', 7, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('e', 7, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('f', 7, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('g', 7, _factory.CreateChessPiece("Pawn", Board, this));
            SetNewPiece('h', 7, _factory.CreateChessPiece("Pawn", Board, this));

        }
    }
}
