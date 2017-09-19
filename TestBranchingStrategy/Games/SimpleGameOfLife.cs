using System;
using System.Collections.Generic;
using System.Text;

namespace TestBranchingStrategy.Games
{
    class SimpleGameOfLife
    {
        HashSet<(int, int)> Board { get; set; }

        public SimpleGameOfLife(params (int, int)[] args)
        {
            Board = new HashSet<(int, int)>(args);
        }

        public bool Running()
        {
            return Board.Count > 0;
        }

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

        public void Move()
        {
            var NewBoard = new HashSet<(int, int)>();
            foreach (var cell in Board)
            {
                // Check each cell if they should live or die.
                int count = 0;
                foreach (var neighbor in Neighbors(cell))
                {
                    if (Board.Contains(neighbor))
                    {
                        count++;
                    }
                    else
                    {
                        // Also check each dead neighbor if it should become alive.
                        int count2 = 0;
                        foreach (var neighborsNeighbors in Neighbors(neighbor))
                        {
                            count2 += Board.Contains(neighborsNeighbors) ? 1 : 0;
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
            Board = NewBoard;
        }

        public string Test()
        {
            return String.Join(" : ", Board);
        }
    }
}
