namespace Exam2
{
    // 매개변수로 주기도 하고 함수에서 처리하면 반환받을 수 있도록 해라
    class Program
    {
        private static void Add(int i, ref int result)
        {
            result += i;
        }

        static void Main(string[] args)
        {
            int total = 10;
            Console.WriteLine(total);
            Add(200, ref total);
            Console.WriteLine(total);
        }
    }
}
