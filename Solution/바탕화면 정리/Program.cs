namespace 바탕화면_정리
{
    /// <summary>
    /// 프로그래머스 - 첫 번째 단계
    /// 바탕화면 정리
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();
            string[] wallpaper = new string[]
            {
                ".#...",
                "..#..",
                "...#."
            };

            int[] answer = solution.solution(wallpaper);
            Console.WriteLine(string.Join(", ", answer));
        }
    }

    public class Solution
    {
        public int[] solution(string[] wallpaper)
        {
            int[] answer = new int[] { };
            
            int minRow = int.MaxValue;
            int minColumn = int.MaxValue;
            int maxRow = int.MinValue;
            int maxColumn = int.MinValue;

            for (int row = 0; row < wallpaper.Length; row++)
            {
                for (int column = 0; column < wallpaper[row].Length; column++)
                {
                    if (wallpaper[row][column] == '#')
                    {
                        if (minRow > row)
                        {
                            minRow = row;
                        }

                        if (minColumn > column)
                        {
                            minColumn = column;
                        }

                        if (maxRow < row)
                        {
                            maxRow = row;
                        }

                        if (maxColumn < column)
                        {
                            maxColumn = column;
                        }
                    }
                }
            }

            answer = [minRow, minColumn, maxRow + 1, maxColumn + 1];
            return answer;
        }
    }
}
