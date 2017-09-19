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

            var SimpleGlider = new (int, int)[] { (0, 0), (1, 0), (2, 0), (0, 1), (1, 2) };

            var SimpleGame = new SimpleGameOfLife(SimpleGlider);

            for (int i = 0; i < 10; i++)
            {
                SimpleGame.Move();
            }

            var GameResult = SimpleGame.Test();

            Console.WriteLine("Simple Game: " + GameResult);

            var set = new HashSet<(int, int)>() { (0, 0), (1, 0), (2, 0), (0, 1), (1, 2) };
            for (int i = 0; i < 10; i++)
            {
                set = ASecondSolution.Move(set);
            }

            var GameResult2 = String.Join(" : ", set);

            Console.WriteLine("Second Game: " + GameResult2);

            Console.ReadKey();
        }
    }
}