using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.board
{
    public interface IChessPiece
    {
        public  bool[,] checkMove();
    }
}
