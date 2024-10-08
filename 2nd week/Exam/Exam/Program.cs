namespace Exam
{
    // 정수형 배열을 입력받아 배열의 모든 요소의 합을 출력하는 함수를 완성해주세요.
    class Program
    {
        static int Sum(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int[] ints = { 3, 6, 7, 9 };
            Console.WriteLine(Sum(ints));
        }
    }
}
