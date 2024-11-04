namespace _8_Queens
{
    public class HeuristicCalculator
    {
        public int CalculateHeuristic(int[] state)
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

        public int[] GetBestNeighbor(int[] state)
        {
            int[] bestNeighbor = (int[])state.Clone();
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
    }
}
