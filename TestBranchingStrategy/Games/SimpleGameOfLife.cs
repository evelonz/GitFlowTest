using System;
using System.Collections.Generic;
using System.Text;

namespace TestBranchingStrategy.Games
{
    class SimpleGameOfLife : IGameOfLife
    {
        public HashSet<(int x, int y)> Move(HashSet<(int x, int y)> board)
        {
            var NewBoard = new HashSet<(int, int)>();

            foreach (var cell in board)
            {
                // Check each cell if they should live or die.
                int count = 0;
                foreach (var neighbor in Neighbors(cell))
                {
                    if (board.Contains(neighbor))
                    {
                        count++;
                    }
                    else
                    {
                        // Also check each dead neighbor if it should become alive.
                        int count2 = 0;
                        foreach (var neighborsNeighbors in Neighbors(neighbor))
                        {
                            count2 += board.Contains(neighborsNeighbors) ? 1 : 0;
                        }
                        if (count2 == 3)
                        {
                            NewBoard.Add(neighbor);
                        }
                    }
                }
                if (count == 2 || count == 3)
                {
                    NewBoard.Add(cell);
                }
            }

            return NewBoard;
        }

        private IEnumerable<(int x, int y)> Neighbors((int x, int y) cell)
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

        public string Test(HashSet<(int x, int y)>board)
        {
            return String.Join(" : ", board);
        }

        
    }
}
