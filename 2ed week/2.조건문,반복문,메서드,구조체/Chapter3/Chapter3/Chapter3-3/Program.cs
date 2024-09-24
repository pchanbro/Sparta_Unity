namespace Chapter3_3
{

    internal class Program
    {
        static void CountDown(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine(n);
                CountDown(n - 1);  // 자기 자신을 호출
            }
        }


        static void Main(string[] args)
        {
            // 메서드 호출
            CountDown(5);
        }
    }
}
