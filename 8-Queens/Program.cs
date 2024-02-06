using System;

namespace _8_Queens
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] solution = SolveQueensProblem();
            PrintBoard(solution);
        }

        private static int[] SolveQueensProblem()
        {
            int[] currentState = GenerateRandomState();
            int[] solution = currentState;
            int stateChanges = 0;
            int restarts = 0;

            while (!IsGoalState(currentState))
            {
                int[] neighbor = GetBestNeighbor(currentState);
                int currentHeuristic = CalculateHeuristic(currentState);

                Console.WriteLine();
                Console.WriteLine("Current h: " + currentHeuristic);
                PrintBoard(currentState);
                int lowerHeuristic = currentHeuristic - CalculateHeuristic(neighbor);
                Console.WriteLine("Neighbors found with lower h: " + lowerHeuristic);

                if (lowerHeuristic == 0)
                {
                    Console.WriteLine("RESTART");
                    currentState = GenerateRandomState();
                    restarts++;
                }
                else
                {
                    Console.WriteLine("Setting new current state");
                    currentState = neighbor;
                    stateChanges++;
                }

                if (CalculateHeuristic(currentState) < CalculateHeuristic(solution))
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

        private static int[] GenerateRandomState()
        {
            int[] state = new int[8];
            Random random = new Random();

            for (int i = 0; i < state.Length; i++)
            {
                state[i] = random.Next(8);
            }

            return state;
        }

        private static bool IsGoalState(int[] state)
        {
            for (int i = 0; i < state.Length; i++)
            {
                for (int j = i + 1; j < state.Length; j++)
                {
                    if (state[i] == state[j] || Math.Abs(state[i] - state[j]) == Math.Abs(i - j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static int[] GetBestNeighbor(int[] state)
        {
            int[] bestNeighbor = state;
            int currentHeuristic = CalculateHeuristic(state);

            for (int i = 0; i < state.Length; i++)
            {
                for (int j = 0; j < state.Length; j++)
                {
                    int[] neighbor = (int[])state.Clone();
                    neighbor[i] = j;
                    int neighborHeuristic = CalculateHeuristic(neighbor);

                    if (neighborHeuristic < currentHeuristic)
                    {
                        bestNeighbor = neighbor;
                        currentHeuristic = neighborHeuristic;
                    }
                }
            }

            return bestNeighbor;
        }

        private static int CalculateHeuristic(int[] state)
        {
            int heuristic = 0;

            for (int i = 0; i < state.Length; i++)
            {
                for (int j = i + 1; j < state.Length; j++)
                {
                    if (state[i] == state[j] || Math.Abs(state[i] - state[j]) == Math.Abs(i - j))
                    {
                        heuristic++;
                    }
                }
            }

            return heuristic;
        }

        private static void PrintBoard(int[] state)
        {
            int[,] board = new int[8, 8];

            for (int i = 0; i < state.Length; i++)
            {
                board[state[i], i] = 1;
            }

            Console.WriteLine("Current State");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i, j] + ",");
                }
                Console.WriteLine();
            }
        }
    }
}
