namespace 동영상재생기
{
    /// <summary>
    /// Programmers - Lv1
    /// 동영상 재생기
    /// PCCP 기출문제
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();
            string video_len = "34:33";
            string pos = "13:00";
            string op_start = "00:55";
            string op_end = "02:55";

            string[] commands = new string[]
            {
                "next", "prev"
            };
            
            string answer = solution.solution(video_len, pos, op_start, op_end, commands);
            Console.Write(answer);
        }
    }

    public class Solution()
    {
        public string solution(string video_len, string pos, string op_start, string op_end, string[] commands)
        {
            string answer = "";

            int videoTime = GetTotalTime(video_len);
            int currentPos = GetTotalTime(pos);
            int opStart = GetTotalTime(op_start);
            int opEnd = GetTotalTime(op_end);

            const int nextSecond = 10;
            const int prevSecond = -10;

            for (int i = 0; i < commands.Length; i++)
            {
                if (opStart <= currentPos && currentPos <= opEnd)
                {
                    currentPos = opEnd;
                }

                if (commands[i] == "next")
                {
                    currentPos = Math.Min(currentPos + nextSecond, videoTime);
                }
                else if (commands[i] == "prev")
                {
                    currentPos = Math.Max(currentPos + prevSecond, 0);
                }

                if (opStart <= currentPos && currentPos <= opEnd)
                {
                    currentPos = opEnd;
                }
            }

            answer = GetTimeText(currentPos);
            return answer;
        }

        private int GetTotalTime(string time)
        {
            int separatorIndex = time.IndexOf(":");

            int minute = int.Parse(time.AsSpan(0, separatorIndex));
            int second = int.Parse(time.AsSpan(separatorIndex + 1));

            return minute * 60 + second;
        }

        private string GetTimeText(int time)
        {
            int minute = time / 60;
            int second = time % 60;

            return $"{minute:D2}:{second:D2}";
        }
    }
}
