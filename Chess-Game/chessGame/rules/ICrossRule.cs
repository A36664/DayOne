using board;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.chessGame.rules
{
    internal interface ICrossRule
    {
        void CrossUpRightAndDownLeft(ref bool[,] boolboard, ref Position position);
        void CrossUpLeftAndDownRight(ref bool[,] boolboard, ref Position position);


    }
}
