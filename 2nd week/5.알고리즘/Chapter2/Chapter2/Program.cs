namespace Chapter2
{
    internal class Program
    {
        // 선택 정렬
        //- 선택 정렬은 배열에서 최소값(또는 최대값)을 찾아 맨 앞(또는 맨 뒤)와 교환하는 방법입니다.
        //- 시간 복잡도: 최악의 경우와 평균적인 경우 모두 O(n^2)
        //- 공간 복잡도: O(1) (상수 크기의 추가 공간이 필요하지 않음)
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 2, 4, 6, 1, 3 };

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }

            foreach (int num in arr)
            {
                Console.WriteLine(num);
            }
        }
    }
}
