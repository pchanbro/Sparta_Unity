namespace homework
{
    // Largest Rectangle in Histogram : 문제 번호 84
    // 히스토그램에서 최대 직사각형의 넓이를 찾기
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] heights = new int[] { 2, 1, 5, 6, 2, 3 };
            int answer = LargestRectangleArea(heights);
            Console.WriteLine(answer);
        }

        public static int LargestRectangleArea(int[] heights)
        {
            int result = 0;
            int width = 0;
            int height = 0;

            for(int i = 0; i < heights.Length ;i++)
            {
                height = heights[i];
                width = 1;
                if (result < heights[i])
                {
                    result = heights[i];
                }

                for(int j = i + 1; j < heights.Length; j++)
                {
                    if (heights[j] == 0)
                    {
                        break;
                    }

                    width++;
                    if(heights[j] < height)
                    {
                        height = heights[j];
                    }

                    if(result < (width * height))
                    {
                        result = width * height;
                    }
                }
            }

            return result;
        }

        //아래 방식이 Stack을 이용한 풀이 시간이 매우 감소된다.
        //public static int LargestRectangleArea(int[] heights)
        //{
        //    Stack<int> stack = new Stack<int>();
        //    int maxArea = 0;
        //    int i = 0;

        //    while (i < heights.Length)
        //    {
        //        // 현재 막대가 스택의 꼭대기보다 크거나 같으면 스택에 추가
        //        if (stack.Count == 0 || heights[stack.Peek()] <= heights[i])
        //        {
        //            stack.Push(i++);
        //        }
        //        else
        //        {
        //            // 현재 막대가 더 작으면 스택에서 꺼내고 넓이 계산
        //            int height = heights[stack.Pop()];
        //            int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
        //            maxArea = Math.Max(maxArea, height * width);
        //        }
        //    }

        //    // 남아있는 스택 처리
        //    while (stack.Count > 0)
        //    {
        //        int height = heights[stack.Pop()];
        //        int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
        //        maxArea = Math.Max(maxArea, height * width);
        //    }

        //    return maxArea;
        //}
    }
}
