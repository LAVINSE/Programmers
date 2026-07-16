namespace 개인정보_수집_유효기간
{
    /// <summary>
    /// 프로그래머스 - 첫 번째 단계
    /// 개인정보 수집 유효기간
    /// C#
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();

            string today = "2022.05.19";
            string[] terms = ["A 6", "B 12", "C 3"];
            string[] privacies =
            [
                "2021.05.02 A",
                "2021.07.01 B",
                "2022.02.19 C",
                "2022.02.20 C"
            ];

            int[] answer = solution.solution(today, terms, privacies);
            Console.WriteLine(string.Join(", ", answer));
        }
    }

    public class Solution
    {
        /// <summary>
        /// 오늘 날짜를 기준으로 파기해야 할 개인정보 번호를 구합니다.
        /// </summary>
        /// <param name="today">오늘 날짜입니다.</param>
        /// <param name="terms">약관 종류별 유효기간입니다.</param>
        /// <param name="privacies">수집된 개인정보의 날짜와 약관 종류입니다.</param>
        /// <returns>파기해야 할 개인정보 번호를 반환합니다.</returns>
        public int[] solution(string today, string[] terms, string[] privacies)
        {
            string[] todays = today.Split('.');
            int yearDay = int.Parse(todays[0]) * 12 * 28;
            int monthDay = int.Parse(todays[1]) * 28;
            int day = int.Parse(todays[2]);

            int totalToday = yearDay + monthDay + day;

            Dictionary<string, int> termMonths = new();
            List<int> answerList = new();

            for (int i = 0; i < terms.Length; i++)
            {
                string[] term = terms[i].Split(" ");
                termMonths.Add(term[0], int.Parse(term[1]));
            }
            
            for(int i = 0; i < privacies.Length; i++)
            {
                string[] privacy = privacies[i].Split(' ');
                string type = privacy[1];
                string[] privacyDate = privacy[0].Split('.');
                int privacyYearDay = int.Parse(privacyDate[0]) * 12 * 28;
                int privacyMonthDay = int.Parse(privacyDate[1]) * 28;
                int privacyDay = int.Parse(privacyDate[2]);
                int privacyTotalDay = privacyYearDay + privacyMonthDay + privacyDay;

                int termMonthDay = termMonths[type] * 28;

                if(privacyTotalDay + termMonthDay <= totalToday)
                {
                    answerList.Add(i + 1);
                }
            }

            return answerList.ToArray();
        }
    }
}
