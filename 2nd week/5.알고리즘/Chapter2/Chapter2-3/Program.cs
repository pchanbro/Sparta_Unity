namespace Chapter2_3
{
    internal class Program
    {
    //- **퀵 정렬(Quick Sort)**
    //- 퀵 정렬은 피벗을 기준으로 작은 요소들은 왼쪽, 큰 요소들은 오른쪽으로 분할하고 이를 재귀적으로 정렬하는 방법입니다.
    //- 시간 복잡도: 최악의 경우 O(n^2), 하지만 평균적으로 O(n log n)
    //- 공간 복잡도: 평균적으로 O(log n), 최악의 경우 O(n) (재귀 호출에 필요한 스택 공간)
        static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                QuickSort(arr, left, pivot - 1);
                QuickSort(arr, pivot + 1, right);
            }
        }

        static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);

            return i + 1;
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 2, 4, 6, 1, 3 };

            QuickSort(arr, 0, arr.Length - 1);

            foreach (int num in arr)
            {
                Console.WriteLine(num);
            }

        }
    }
}
