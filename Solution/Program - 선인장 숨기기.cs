

/// <summary>
/// Programmers - Lv2
/// 선인장 숨기기
/// 20205 카카오 하반기 2차
/// C#
/// </summary>

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        int[,] drops =
        {
            { 0, 0 },
            { 3, 1 },
            { 1, 3 },
            { 2, 4 },
            { 1, 1 },
            { 2, 2 },
            { 2, 3 },
            { 0, 4 }
        };

        int[] result = solution.solution(4, 5, 2, 2, drops);

        Console.WriteLine(string.Join(", ", result));
        Console.WriteLine(result[0] == 2 && result[1] == 2 ? "테스트 성공" : "테스트 실패");
    }
}

public class Solution
{
    public int[] solution(int m, int n, int h, int w, int[,] drops)
    {
        int[] answer = new int[] { };

        int dropCount = drops.GetLength(0); // 빗방울 수
        int neverRain = dropCount + 1; // 빗방울 없는 곳
        int horizontalWindowCount = n - w + 1; // 선인장 가로 구역
        int verticalWindowCount = m - h + 1; // 선인장 세로 구역
        int[,] maps = new int[m, n]; // 격자

        int[,] horizontalMinRain = new int[m, horizontalWindowCount]; // 각 행에서 너비가 w인 가로 구간의 최소 빗방울 시점
        int[,] areaMin = new int[verticalWindowCount, horizontalWindowCount]; // 각 h x w 구역의 최소 빗방울 시점

        int[] horizontalCandidate = new int[n]; // 가로 윈도우의 최솟값 후보 열
        int[] verticalCandidate = new int[m]; // 세로 윈도우의 최솟값 후보 행
        
        int bestRainTime = -1; // 현재까지 찾은 구역 중 가장 늦은 빗방울 시점
        int bestRow = 0; // 최적의 선인장 구역의 시작 행
        int bestColumn = 0; // 최적의 선인장 구역의 시작 열
        

        // 초기화
        for (int row = 0; row < m; row++)
        {
            for (int column = 0; column < n; column++)
            {
                maps[row, column] = neverRain;
            }
        }

        // 빗방울 적용
        for (int i = 0; i < dropCount; i++)
        {
            int row = drops[i, 0];
            int column = drops[i, 1];

            maps[row, column] = i + 1;
        }

        // 각 행에서 길이가 w인 구간의 최솟값 계산
        for (int row = 0; row < m; row++)
        {
            int frontIndex = 0; // 첫 번째 원소 위치
            int backIndex = 0; // 다음 원소를 넣을 위치

            for (int column = 0; column < n; column++)
            {
                while (frontIndex < backIndex && horizontalCandidate[frontIndex] <= column - w)
                {
                    frontIndex++;
                }

                while (frontIndex < backIndex && maps[row, horizontalCandidate[backIndex - 1]] >= maps[row, column])
                {
                    backIndex--;
                }

                horizontalCandidate[backIndex] = column;
                backIndex++;

                if (column >= w - 1)
                {
                    int startColumn = column - w + 1;

                    horizontalMinRain[row, startColumn] = maps[row, horizontalCandidate[frontIndex]];
                }
            }
        }

        // 가로 최솟값을 이용해 h x w 구역의 최솟값 계산
        for (int column = 0; column < horizontalWindowCount; column++)
        {
            int frontIndex = 0;
            int backIndex = 0;

            for (int row = 0; row < m; row++)
            {
                while (frontIndex < backIndex && verticalCandidate[frontIndex] <= row - h)
                {
                    frontIndex++;
                }

                while (frontIndex < backIndex && horizontalMinRain[verticalCandidate[backIndex - 1], column] >= horizontalMinRain[row, column])
                {
                    backIndex--;
                }

                verticalCandidate[backIndex] = row;
                backIndex++;

                if (row >= h - 1)
                {
                    int startRow = row - h + 1;

                    areaMin[startRow, column] = horizontalMinRain[verticalCandidate[frontIndex], column];
                }
            }
        }
        
        // 위에서 아래, 왼쪽에서 오른쪽 순서로 확인
        for(int row = 0; row < verticalWindowCount; row++)
        {
            for(int column = 0; column < horizontalWindowCount; column++)
            {
                if (areaMin[row, column] <= bestRainTime)
                {
                    continue;
                }

                bestRainTime = areaMin[row, column];
                bestRow = row;
                bestColumn = column;
            }
        }

        answer = new int[] {bestRow, bestColumn};
        return answer;
    }
}