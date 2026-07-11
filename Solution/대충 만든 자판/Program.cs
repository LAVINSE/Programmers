namespace 대충_만든_자판
{
    /// <summary>
    /// 프로그래머스 - 첫 번째 단계
    /// 대충 만든 자판
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();
            string[] keyMap = new string[] { "ABACD", "BCEFD" };
            string[] targets = new string[] { "ABCD", "AABB" };

            int[] answer = solution.solution(keyMap, targets);
            Console.WriteLine(string.Join(", ", answer));
        }
    }

    public class Solution
    {
        public int[] solution(string[] keymap, string[] targets)
        {
            int[] answer = new int[targets.Length];

            Dictionary<char, int> dict = new();
            int totalCount = 0;

            for (int keyIndex = 0; keyIndex < keymap.Length; keyIndex++)
            {
                string keys = keymap[keyIndex];

                for (int charIndex = 0; charIndex < keys.Length; charIndex++)
                {
                    char keyChar = keys[charIndex];
                    int pressIndex = charIndex + 1;

                    // 값 없으면 추가
                    if (!dict.ContainsKey(keyChar))
                    {
                        dict.Add(keyChar, pressIndex);
                    }
                    // 값 있으면 작은 값 저장
                    else if (pressIndex < dict[keyChar])
                    {
                        dict[keyChar] = pressIndex;
                    }
                }
            }
            
            for(int i = 0; i < targets.Length; i++)
            {
                foreach (var target in targets[i])
                {
                    // 문자 없으면 -1
                    if (!dict.TryGetValue(target, out int pressIndex))
                    {
                        totalCount = -1;
                        break;
                    }

                    totalCount += pressIndex;
                }

                answer[i] = totalCount;
                totalCount = 0;
            }

            
            return answer;
        }
    }
}
