using System;
using System.Collections.Generic;
using TestBranchingStrategy.Games;

namespace TestBranchingStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Conway's Game of Life!");

            var StartBoard = new HashSet<(int, int)>() { (0, 0), (1, 0), (2, 0), (0, 1), (1, 2) };
            var NeighborFactory = new SimpleNeighbors();

            var CurrentSet = StartBoard;
            var SimpleGame = new SimpleGameOfLife();
            for (int i = 0; i < 10; i++)
            {
                CurrentSet = SimpleGame.Move(CurrentSet, NeighborFactory);
            }

            Console.WriteLine("Simple Game: " + FormatResylt(CurrentSet));

            CurrentSet = StartBoard;
            var SecondGame = new ASecondSolution();
            for (int i = 0; i < 10; i++)
            {
                CurrentSet = SecondGame.Move(CurrentSet, NeighborFactory);
            }

            Console.WriteLine("Second Game: " + FormatResylt(CurrentSet));

            Console.ReadKey();
        }

        private static string FormatResylt(HashSet<(int, int)> set)
        {
            return String.Join(" : ", set);
        }
    }
}