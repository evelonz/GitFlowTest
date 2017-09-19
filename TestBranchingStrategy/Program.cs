using System;
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

            for (int i = 0; i < 1000; i++)
            {
                SimpleGame.Move();
            }

            var GameResult = SimpleGame.Test();

            Console.WriteLine(GameResult);

            Console.ReadKey();
        }
    }
}