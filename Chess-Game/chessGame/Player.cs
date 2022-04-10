using board;
using Chess.board;
using Chess.Factory;
using chessGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.chessGame
{
     class Player
    {
        
        private string _name;
        public Colour PlayerTurn { get; private set; }
        public string Name { get => _name;  }

        private  ChessTurns _turns;

        public Player(string name, Colour colour, ChessTurns chessTurns)
        {

            PlayerTurn = colour;
            this._name = name;

            _turns = chessTurns;
            
            
        }

        public void takeTurn()
        {
            _turns.PlayerTurn=PlayerTurn;

            Console.Clear();
            Cover.PrintGame(_turns);

            Console.Write("\nSelect: ");
            Position origin = Cover.ReadPiecePosition().ToPosition();
            _turns.OriginPositionValidation(origin);

            bool[,] possiblePosition = _turns.Board.Piece(origin).checkMove();

            Console.Clear();
            Cover.PrintBoard(_turns.Board, possiblePosition);

            Console.Write("\nDestination: ");
            Position destination = Cover.ReadPiecePosition().ToPosition();
            _turns.DestinationPositionValidation(origin, destination);
            _turns.Play(origin, destination);
        }



    }

   
}
