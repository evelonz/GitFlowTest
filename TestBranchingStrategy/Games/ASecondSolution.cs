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

        public static readonly System.Numerics.Vector<int> dx = new System.Numerics.Vector<int>(new int[] { -1, -1, -1, 0, 0, 1, 1, 1 });
        public static readonly System.Numerics.Vector<int> dy = new System.Numerics.Vector<int>(new int[] { 0, 1, -1, 1, -1, 0, 1, -1 });

        private static IEnumerable<(int x, int y)> Neighbors((int x, int y) cell)
        {
            var vx = new System.Numerics.Vector<int>(cell.x);
            var vy = new System.Numerics.Vector<int>(cell.y);

            // TODO: Check how we can enforce the SIMD?
            //var t = System.Numerics.Vector.IsHardwareAccelerated;
            var xx = System.Numerics.Vector.Add<int>(vx, dx);
            var yy = System.Numerics.Vector.Add<int>(vy, dy);

            yield return (xx[0], yy[0]);
            yield return (xx[1], yy[1]);
            yield return (xx[2], yy[2]);
            //yield return (xx[0], yy[0]); // Self!
            yield return (xx[3], yy[3]);
            yield return (xx[4], yy[4]);
            yield return (xx[5], yy[5]);
            yield return (xx[6], yy[6]);
            yield return (xx[7], yy[7]);
        }
    }
}
