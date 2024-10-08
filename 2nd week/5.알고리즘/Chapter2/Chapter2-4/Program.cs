namespace Chapter2_4
{
    internal class Program
    {
        //- **병합 정렬(Merge Sort)**
        //- 병합 정렬은 배열을 반으로 나누고, 각 부분을 재귀적으로 정렬한 후, 병합하는 방법입니다.
        //- 시간 복잡도: 모든 경우에 대해 O(n log n)
        //- 공간 복잡도: O(n) (정렬을 위한 임시 배열이 필요함)
        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int[] temp = new int[arr.Length];

            int i = left;
            int j = mid + 1;
            int k = left;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                }
            }

            while (i <= mid)
            {
                temp[k++] = arr[i++];
            }

            while (j <= right)
            {
                temp[k++] = arr[j++];
            }

            for (int l = left; l <= right; l++)
            {
                arr[l] = temp[l];
            }
        }


        static void Main(string[] args)
    {

        int[] arr = new int[] { 5, 2, 4, 6, 1, 3 };

        MergeSort(arr, 0, arr.Length - 1);

        foreach (int num in arr)
        {
            Console.WriteLine(num);
        }
    }
}
