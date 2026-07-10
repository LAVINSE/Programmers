namespace 덧칠_하기
{
    /// <summary>
    /// 프로그래머스 - 덧칠 하기
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();
            int[] section = new int[] { 2, 3, 6 };

            int answer = solution.solution(8, 4, section);
            Console.WriteLine(answer);
        }
    }

    public class Solution
    {
        public int solution(int n, int m, int[] section)
        {
            int answer = 0;
            int paintIndex = 0;

            for (int i = 0; i < section.Length; i++)
            {
                int value = section[i];

                if(paintIndex < value)
                {
                    paintIndex = value + m - 1;
                    answer++;
                }
            }

            return answer;
        }
    }
}
