namespace 택배상자꺼내기
{
    /// <summary>
    /// 프로그래머스
    /// 택배 상자 꺼내기
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();

            int answer = solution.solution(22, 6, 8);

            Console.WriteLine(answer);
        }
    }

    public class Solution
    {
        public int solution(int n, int w, int num)
        {
            int answer = 0;

            int targetFloorIndex = (num - 1) / w;
            int targetPositionIndex = (num - 1) % w;
            int targetColumn = targetFloorIndex % 2 == 0 ? targetPositionIndex : w - 1 - targetPositionIndex;

            for(int i = num; i <= n; i++)
            {
                int floor = (i - 1) / w;
                int position = (i - 1) % w;
                int column = floor % 2 == 0 ? position : w - 1 - position;
                
                if(column == targetColumn)
                {
                    answer++;
                }
            }

            return answer;
        }
    }
}
