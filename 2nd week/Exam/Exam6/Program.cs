namespace Exam6
{
    class Program
    {
        // 다음 배열을 오름차순으로 정렬시켜라
        static void Main(string[] args)
        {
            int[] intArr = { 4, 7, 2, 5, 6, 8, 3 };

            Array.Sort(intArr);
    
            foreach (int i in intArr)
                Console.Write(i + " ");

        }
    }
}
