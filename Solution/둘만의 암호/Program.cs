using System.Text;

namespace 둘만의_암호
{
    /// <summary>
    /// 프로그래머스 - 첫 번째 단계
    /// 둘만의 암호
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();

            string answer = solution.solution("aukks", "wbqd", 5);
            Console.WriteLine(answer);
        }
    }

    public class Solution
    {
        /// <summary>
        /// 주어진 문자열을 규칙에 따라 변환합니다.
        /// </summary>
        /// <param name="s">변환할 문자열입니다.</param>
        /// <param name="skip">변환할 때 제외할 문자들입니다.</param>
        /// <param name="index">각 문자를 이동할 거리입니다.</param>
        /// <returns>변환한 문자열을 반환합니다.</returns>
        public string solution(string s, string skip, int index)
        {
            string answer = "";
            StringBuilder stringBuilder = new();

            for (int i = 0; i < s.Length; i++)
            {
                char currentCharacter = s[i];
                int moveCount = 0;

                while (moveCount < index)
                {
                    currentCharacter++;

                    if (currentCharacter > 'z')
                    {
                        currentCharacter = 'a';
                    }

                    if (skip.Contains(currentCharacter))
                    {
                        continue;
                    }

                    moveCount++;
                }

                stringBuilder.Append(currentCharacter);
            }

            answer = stringBuilder.ToString();
            return answer;
        }
    }
}
