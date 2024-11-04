using System;

namespace _8_Queens
{
    public class Board
    {
        public int[] GenerateRandomState()
        {
            int[] state = new int[8];
            Random random = new Random();
            for (int i = 0; i < state.Length; i++)
            {
                state[i] = random.Next(8);
            }
            return state;
        }

        public void PrintBoard(int[] state)
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
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool IsGoalState(int[] state)
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
    }
}
