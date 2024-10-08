namespace Exam10
{
    // 배열을 입력받아 오름차순으로 정렬하는 함수를
    // 자유로운 방식으로 직접 구현해주세요.
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 5, 1, 6, 7, 2, 5, 7, 4, 7, 4, 2, 7, 9 };
            OrderByIncrease(arr);

            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        }

        public static void OrderByIncrease(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
