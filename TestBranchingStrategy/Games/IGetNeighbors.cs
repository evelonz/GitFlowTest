using System;
using System.Collections.Generic;
using System.Text;

namespace TestBranchingStrategy.Games
{
    interface IGetNeighbors
    {
        IEnumerable<(int x, int y)> Neighbors((int x, int y) cell);
    }

    class SimpleNeighbors : IGetNeighbors
    {
        public IEnumerable<(int x, int y)> Neighbors((int x, int y) cell)
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

    class SimdNeighbors : IGetNeighbors
    {
        private static readonly System.Numerics.Vector<int> dx = new System.Numerics.Vector<int>(new int[] { -1, -1, -1, 0, 0, 1, 1, 1 });
        private static readonly System.Numerics.Vector<int> dy = new System.Numerics.Vector<int>(new int[] { 0, 1, -1, 1, -1, 0, 1, -1 });

        public IEnumerable<(int x, int y)> Neighbors((int x, int y) cell)
        {
            var vx = new System.Numerics.Vector<int>(cell.x);
            var vy = new System.Numerics.Vector<int>(cell.y);

            // TODO: Check how we can enforce the SIMD? Who the hell leaves todoes in production code!
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
