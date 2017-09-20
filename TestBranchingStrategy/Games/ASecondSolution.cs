using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBranchingStrategy.Games
{
    class ASecondSolution : IGameOfLife
    {
        public HashSet<(int x, int y)> Move(HashSet<(int x, int y)> board, IGetNeighbors getNeighbors)
        {
            HashSet<(int x, int y)> NewBoard = new HashSet<(int x, int y)>();
            HashSet<(int x, int y)> recalc = new HashSet<(int x, int y)>(board);
            // TODO: 2
            board.Select(o => getNeighbors.Neighbors(o)).ToList().ForEach(e => recalc.UnionWith(e));
            foreach (var point in recalc)
            {
                var Count = getNeighbors.Neighbors(point).Sum(s => board.Contains(s) ? 1 : 0);
                if (Count == 3 || (Count == 2 && board.Contains(point)))
                {
                    NewBoard.Add(point);
                }
            }

            return NewBoard;
        }
    }
}
