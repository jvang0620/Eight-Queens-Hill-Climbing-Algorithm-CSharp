using System;

namespace _8_Queens
{
    public class Solver
    {
        private readonly Board board;
        private readonly HeuristicCalculator heuristicCalculator;

        public Solver()
        {
            board = new Board();
            heuristicCalculator = new HeuristicCalculator();
        }

        public int[] SolveQueensProblem()
        {
            int[] currentState = board.GenerateRandomState();
            int[] solution = currentState;
            int stateChanges = 0;
            int restarts = 0;

            while (!board.IsGoalState(currentState))
            {
                int[] neighbor = heuristicCalculator.GetBestNeighbor(currentState);
                int currentHeuristic = heuristicCalculator.CalculateHeuristic(currentState);

                Console.WriteLine();
                Console.WriteLine("Current h: " + currentHeuristic);
                board.PrintBoard(currentState);
                int lowerHeuristic = currentHeuristic - heuristicCalculator.CalculateHeuristic(neighbor);
                Console.WriteLine("Neighbors found with lower h: " + lowerHeuristic);

                if (lowerHeuristic == 0)
                {
                    Console.WriteLine("RESTART");
                    currentState = board.GenerateRandomState();
                    restarts++;
                }
                else
                {
                    Console.WriteLine("Setting new current state");
                    currentState = neighbor;
                    stateChanges++;
                }

                if (heuristicCalculator.CalculateHeuristic(currentState) < heuristicCalculator.CalculateHeuristic(solution))
                {
                    solution = currentState;
                }
            }

            Console.WriteLine();
            Console.WriteLine("***Solution Found!***");
            Console.WriteLine("Current State");
            Console.WriteLine("State changes: " + stateChanges);
            Console.WriteLine("Restarts: " + restarts);

            return solution;
        }
    }
}
