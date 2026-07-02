namespace 노란불신호등
{
    /// <summary>
    /// Programmers - Lv1
    /// 노란불 신호등
    /// 2025 카카오 하반기 1차
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();

            int[,] signals =
            {
                {2,1,2},
                {5,1,1}
            };

            int answer = solution.solution(signals);
            Console.Write(answer);
        }
    }

    public class Solution()
    {
        public int solution(int[,] signals)
        {
            int answer = 0;

            int signalCount = signals.GetLength(0);
            int totalTime = 1;

            for (int i = 0; i < signalCount; i++)
            {
                int g = signals[i, 0];
                int y = signals[i, 1];
                int r = signals[i, 2];

                int cycle = g + y + r;
                int leastCommonMultiple = totalTime / GetGreatestCommonDivisor(totalTime, cycle) * cycle;
                totalTime = leastCommonMultiple;
            }

            int[] yellowSignalCounts = new int[totalTime + 1];

            for (int i = 0; i < signalCount; i++)
            {
                int g = signals[i, 0];
                int y = signals[i, 1];
                int r = signals[i, 2];

                int cycle = g + y + r;

                for (int cycleTime = 1; cycleTime <= totalTime; cycleTime += cycle)
                {
                    for (int yOffset = 0; yOffset < y; yOffset++)
                    {
                        int yTime = cycleTime + g + yOffset;
                        yellowSignalCounts[yTime]++;
                    }
                }
            }

            for (int time = 1; time <= totalTime; time++)
            {
                if(yellowSignalCounts[time] == signalCount)
                {
                    answer = time;
                    return answer;
                }
            }

            return -1;
        }
        
        private int GetGreatestCommonDivisor(int first, int second)
        {
            while (second != 0)
            {
                int remainder = first % second;

                first = second;
                second = remainder;
            }

            return first;
        }
    }
}