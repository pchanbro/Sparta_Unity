namespace Chapter2_2
{
    internal class Program
    {
        //- **삽입 정렬(Insertion Sort)**
        //- 삽입 정렬은 정렬되지 않은 부분에서 요소를 가져와 정렬된 부분에 적절한 위치에 삽입하는 방법입니다.
        //- 시간 복잡도: 최악의 경우 O(n^2), 하지만 정렬되어 있는 경우에는 O(n)
        //- 공간 복잡도: O(1) (상수 크기의 추가 공간이 필요하지 않음)
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 2, 4, 6, 1, 3 };

            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;
                int key = arr[i];

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }

            foreach (int num in arr)
            {
                Console.WriteLine(num);
            }
        }
    }
}
