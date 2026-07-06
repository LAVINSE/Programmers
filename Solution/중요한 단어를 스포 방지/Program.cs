namespace 중요한단어를스포방지
{
    /// <summary>
    /// Programmers
    /// 중요한 단어를 스포 방지
    /// 2025 카카오 하반기 1차
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();

            string message = "here is muzi here is a secret message";
            int[,] spoilerRanges =
            {
                { 0, 3 },
                { 23, 28 }
            };

            int result = solution.solution(message, spoilerRanges);

            Console.WriteLine(result);
            Console.WriteLine(result == 1 ? "테스트 성공" : "테스트 실패");
        }
    }

    public class Solution
    {
        public int solution(string message, int[,] spoiler_ranges)
        {
            int answer = 0;
            int spoilerCount = spoiler_ranges.GetLength(0);
            int messageLength = message.Length;
            int[] messageIndex = new int[message.Length];

            HashSet<string> visibleWords = new(); // 처음부터 보이는 단어
            List<string>[] wordsBySpoilerRange = new List<string>[spoilerCount]; // 구간 별 완전히 공개되는 단어 목록
            HashSet<string> showWords = new();

            // 초기화
            for (int i = 0; i < spoilerCount; i++)
            {
                wordsBySpoilerRange[i] = new List<string>();
            }

            // 가려지지 않은 문자 -1 초기화
            Array.Fill(messageIndex, -1);

            // 각 문자에 포함된 스포 방지 구간 번호 기록
            for (int i = 0; i < spoilerCount; i++)
            {
                int startRange = spoiler_ranges[i, 0];
                int endRange = spoiler_ranges[i, 1];

                for (int word = startRange; word <= endRange; word++)
                {
                    messageIndex[word] = i;
                }
            }

            int wordStartIndex = 0;

            for (int i = 0; i <= messageLength; i++)
            {
                bool isEnd = i == messageLength || message[i] == ' ';

                if (!isEnd)
                {
                    continue;
                }

                int wordEndIndex = i - 1;
                int wordLength = wordEndIndex - wordStartIndex + 1;
                string word = message.Substring(wordStartIndex, wordLength);

                int lastSpoilerRangeIndex = -1;

                // 단어가 완전히 공개되는 마지막 구간 확인
                for (int wordIndex = wordStartIndex; wordIndex <= wordEndIndex; wordIndex++)
                {
                    lastSpoilerRangeIndex = Math.Max(lastSpoilerRangeIndex, messageIndex[wordIndex]);
                }

                // 일반 단어와 스포 방지 단어 분류
                if (lastSpoilerRangeIndex == -1)
                {
                    visibleWords.Add(word);
                }
                else
                {
                    wordsBySpoilerRange[lastSpoilerRangeIndex].Add(word);
                }

                wordStartIndex = i + 1;
            }
            
            // 구간은 공개 순서대로 확인
            for(int i = 0; i < spoilerCount; i++)
            {
                foreach(var word in wordsBySpoilerRange[i])
                {
                    bool isVisible = visibleWords.Contains(word); // 처음부터 가려지지 않은 영역에 등장했는지
                    bool isShow = showWords.Contains(word); // 스포 방지 구간을 확인하면서 이전에 공개됐는지

                    if (!isVisible && !isShow)
                    {
                        answer++;
                    }

                    // 
                    showWords.Add(word);
                }
            }

            return answer;
        }
    }
}
