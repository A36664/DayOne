using System;
using board;
using chessGame;
using board.exceptions;
using Chess.chessGame;

namespace Chess
{
    class Game
    {
        static void Main(string[] args)
        {
            try
            {
                ChessTurns chessTurns = new ChessTurns();
                Player whitePlayer = new Player("White Player",Colour.white,chessTurns);
                Player blackPlayer= new Player("Black Player",Colour.black,chessTurns);

                while (!chessTurns.GameOver)
                {
                    try
                    {

                        whitePlayer.takeTurn();
                        blackPlayer.takeTurn();

                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Cover.PrintGame(chessTurns);
            }
            catch(BoardException e)
            {
                Console.WriteLine($"Operation Error: {e.Message}");
            }
        }
    }
}
