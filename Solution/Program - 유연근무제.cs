namespace 유연근무제
{
    /// <summary>
    /// Programmers - Lv1
    /// 유연근무제
    /// 2025 프로그래머스 코드챌린지 1차 예선
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();

            int[] schedules =
            {
            700, 800, 1100
        };

            int[,] timeLogs =
            {
            { 710, 2359, 1050, 700, 650, 631, 659 },
            { 800, 801, 805, 800, 759, 810, 809 },
            { 1105, 1001, 1002, 600, 1059, 1001, 1100 }
        };

            int answer = solution.solution(schedules, timeLogs, 5);

            Console.Write(answer);
        }
    }

    public class Solution()
    {
        public int solution(int[] schedules, int[,] timelogs, int startday)
        {
            int answer = 0;
            int humanCount = schedules.Length;
            const int offset = 10;

            for (int i = 0; i < humanCount; i++)
            {
                int schedule = schedules[i];
                int scheduleOffset = schedule + offset;
                if (scheduleOffset % 100 >= 60)
                {
                    scheduleOffset += 40;
                }
                bool isPass = false;

                for (int j = 0; j < timelogs.GetLength(1); j++)
                {
                    int log = timelogs[i, j];
                    int currentDay = ((startday + j - 1) % 7) + 1;

                    if (currentDay == 6 || currentDay == 7)
                    {
                        continue;
                    }

                    isPass = true;

                    if (log > scheduleOffset)
                    {
                        isPass = false;
                        break;
                    }
                }

                if (isPass)
                {
                    answer++;
                }
            }

            return answer;
        }
    }
}