using System;

namespace _8_Queens
{
    class Program
    {
        static void Main(string[] args)
        {
            Solver solver = new Solver();
            int[] solution = solver.SolveQueensProblem();

            Board board = new Board();
            board.PrintBoard(solution);
        }
    }
}
