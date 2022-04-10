using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.chessGame.rules
{
    internal interface IHoVeRule
    {
        void HorizontalMove(ref bool[,] boolboard, ref Position position);
        void VerticalMove(ref bool[,] boolboard, ref Position position);
    }
}
