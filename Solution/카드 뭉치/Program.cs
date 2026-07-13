namespace 카드_뭉치
{
    /// <summary>
    /// 프로그래머스 - 첫 번째 단계
    /// 카드 뭉치
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();

            string[] cards1 = ["i", "drink", "water"];
            string[] cards2 = ["want", "to"];
            string[] goal = ["i", "want", "to", "drink", "water"];

            string answer = solution.solution(cards1, cards2, goal);
            Console.WriteLine(answer);
        }
    }

    public class Solution
    {
        /// <summary>
        /// 두 카드 뭉치의 단어를 순서대로 사용하여 목표 단어 배열을 만들 수 있는지 확인합니다.
        /// </summary>
        /// <param name="cards1">첫 번째 카드 뭉치입니다.</param>
        /// <param name="cards2">두 번째 카드 뭉치입니다.</param>
        /// <param name="goal">만들어야 하는 목표 단어 배열입니다.</param>
        /// <returns>문제 풀이 결과를 반환합니다.</returns>
        public string solution(string[] cards1, string[] cards2, string[] goal)
        {
            string answer = "";
            int card1Index = 0;
            int card2Index = 0;

            foreach (string goalWord in goal)
            {
                if (card1Index < cards1.Length &&
                    goalWord == cards1[card1Index])
                {
                    card1Index++;
                }
                else if (card2Index < cards2.Length &&
                         goalWord == cards2[card2Index])
                {
                    card2Index++;
                }
                else
                {
                    return "No";
                }
            }

            return "Yes";
        }
    }
}
