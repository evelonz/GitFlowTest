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
}
