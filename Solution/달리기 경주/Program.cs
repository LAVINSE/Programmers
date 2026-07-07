namespace 달리기경주
{
    /// <summary>
    /// 프로그래머스
    /// 달리기 경주
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();

            string[] players = new string[]
            {
                "mumu", "soe", "poe", "kai", "mine"
            };

            string[] callings = new string[]
            {
                "kai", "kai", "mine", "mine"
            };

            string[] answer = solution.solution(players, callings);

            Console.WriteLine(string.Join(", ", answer));
        }
    }

    public class Solution
    {
        public string[] solution(string[] players, string[] callings)
        {
            string[] answer = new string[] { };

            Dictionary<string, int> playerRankingDict = new();

            for(int i = 0; i < players.Length; i++)
            {
                playerRankingDict[players[i]] = i;
            }

            for (int i = 0; i < callings.Length; i++)
            {
                string call = callings[i];

                int callIndex = playerRankingDict[call];
                int prevPlayerIndex = callIndex - 1;

                string prevPlayer = players[prevPlayerIndex];

                players[prevPlayerIndex] = call;
                players[callIndex] = prevPlayer;

                playerRankingDict[call] = prevPlayerIndex;
                playerRankingDict[prevPlayer] = callIndex;
            }

            answer = players;

            return answer;
        }
    }
}
