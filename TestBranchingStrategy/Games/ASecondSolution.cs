using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBranchingStrategy.Games
{
    static class ASecondSolution
    {
        public static HashSet<(int x, int y)> Move(HashSet<(int x, int y)> board)
        {
            HashSet<(int x, int y)> NewBoard = new HashSet<(int x, int y)>();
            HashSet<(int x, int y)> recalc = new HashSet<(int x, int y)>(board);

            board.Select(o => Neighbors(o)).ToList().ForEach(e => recalc.UnionWith(e));
            foreach (var point in recalc)
            {
                var Count = Neighbors(point).Sum(s => board.Contains(s) ? 1 : 0);
                if (Count == 3 || (Count == 2 && board.Contains(point)))
                {
                    NewBoard.Add(point);
                }
            }

            return NewBoard;
        }

        private static IEnumerable<(int x, int y)> Neighbors((int x, int y) cell)
        {
            yield return (cell.x - 1, cell.y);
            yield return (cell.x - 1, cell.y + 1);
            yield return (cell.x - 1, cell.y - 1);
            //yield return (cell.x  , cell.y    )); // Self!
            yield return (cell.x, cell.y + 1);
            yield return (cell.x, cell.y - 1);
            yield return (cell.x + 1, cell.y);
            yield return (cell.x + 1, cell.y + 1);
            yield return (cell.x + 1, cell.y - 1);
        }
    }
}
