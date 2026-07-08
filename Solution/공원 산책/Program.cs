namespace 공원_산책
{
    /// <summary>
    /// Programmers - Lv1
    /// 공원 산책
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();
            string[] park = new string[]
            {
                "SOO",
                "OOO",
                "OOO"
            };

            string[] routes = new string[]
            {
                "E 2",
                "S 2",
                "W 1"
            };

            int[] answer = solution.solution(park, routes);
            Console.WriteLine(string.Join(", ", answer));
        }
    }

    public class Solution
    {
        public int[] solution(string[] park, string[] routes)
        {
            int[] answer = new int[] { };

            int width = park[0].Length;
            int height = park.Length;
            char[,] maps = new char[height, width];

            int x = 0;
            int y = 0;

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    maps[row, column] = park[row][column];

                    if (park[row][column] == 'S')
                    {
                        x = column;
                        y = row;
                    }
                }
            }

            foreach (string routeText in routes)
            {
                string[] routeDatas = routeText.Split(' ');
                string direction = routeDatas[0];
                int moveCount = int.Parse(routeDatas[1]);

                int moveX = 0;
                int moveY = 0;

                switch (direction)
                {
                    case "E": moveX = 1; break;
                    case "W": moveX = -1; break;
                    case "S": moveY = 1; break;
                    case "N": moveY = -1; break;
                }

                int nextX = x + moveX * moveCount;
                int nextY = y + moveY * moveCount;

                if (nextX < 0 || width <= nextX || nextY < 0 || height <= nextY)
                {
                    continue;
                }

                bool canMove = true;
                int checkX = x;
                int checkY = y;

                for (int moveIndex = 1; moveIndex <= moveCount; moveIndex++)
                {
                    checkX += moveX;
                    checkY += moveY;

                    if (maps[checkY, checkX] == 'X')
                    {
                        canMove = false;
                        break;
                    }
                }

                if (canMove)
                {
                    x = nextX;
                    y = nextY;
                }
            }

            answer = [y, x];

            return answer;
        }
    }
}
