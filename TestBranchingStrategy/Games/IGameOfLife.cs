using System;
using System.Collections.Generic;
using System.Text;

namespace TestBranchingStrategy.Games
{
    interface IGameOfLife
    {
        HashSet<(int x, int y)> Move(HashSet<(int x, int y)> board);
    }
}
