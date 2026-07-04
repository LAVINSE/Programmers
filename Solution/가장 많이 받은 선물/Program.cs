namespace 가장많이받은선물
{
    /// <summary>
    /// Programmers - Lv1
    /// 가장 많이 받은 선물
    /// 2024 카카오 윈터 인턴쉽
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();

            string[] friends =
            {
                "muzi",
                "ryan",
                "frodo",
                "neo"
            };

            string[] gifts =
            {
                "muzi frodo",
                "muzi frodo",
                "ryan muzi",
                "ryan muzi",
                "ryan muzi",
                "frodo muzi",
                "frodo ryan",
                "neo muzi"
            };

            int answer = solution.solution(friends, gifts);
            Console.WriteLine(answer);
        }
    }

    public class Solution
    {
        public int solution(string[] friends, string[] gifts)
        {
            Dictionary<string, int> friendIndexDict = new();
            int friendCount = friends.Length;
            int[,] giftCounts = new int[friendCount, friendCount]; // 준 사람, 받은 사람
            int[] givenCounts = new int[friendCount]; // 준 선물 개수
            int[] receivedCounts = new int[friendCount]; // 받은 선물 개수
            int[] giftScore = new int[friendCount]; // 선물 지수
            int[] nextGiftCounts = new int[friendCount]; // 받을 선물 개수

            for (int i = 0; i < friendCount; i++)
            {
                friendIndexDict.Add(friends[i], i);
            }

            // 선물 기록
            for (int i = 0; i < gifts.Length; i++)
            {
                string[] names = gifts[i].Split(' ');

                int giverIndex = friendIndexDict[names[0]]; // 준 사람
                int receiverIndex = friendIndexDict[names[1]]; // 받은 사람

                giftCounts[giverIndex, receiverIndex]++;
                givenCounts[giverIndex]++;
                receivedCounts[receiverIndex]++;
            }

            // 선물 지수
            for (int i = 0; i < friendCount; i++)
            {
                giftScore[i] = givenCounts[i] - receivedCounts[i];
            }

            // 비교
            for(int first = 0; first < friendCount; first++)
            {
                for(int second = first + 1; second < friendCount; second++)
                {
                    int firstToSecond = giftCounts[first, second];
                    int secondToFirst = giftCounts[second, first];

                    if (firstToSecond > secondToFirst)
                    {
                        nextGiftCounts[first]++;
                    }
                    else if (firstToSecond < secondToFirst)
                    {
                        nextGiftCounts[second]++;
                    }
                    else if (giftScore[first] > giftScore[second])
                    {
                        nextGiftCounts[first]++;
                    }
                    else if (giftScore[first] < giftScore[second])
                    {
                        nextGiftCounts[second]++;
                    }
                }
            }

            return nextGiftCounts.Max();
        }
    }
}
