namespace Chapter3
{
    internal class Program
    {
        static void PrintLine() // main 함수가 static 이기 때문에 함수도 static로 만들어 줘야 한다.
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        static void PrintLine2(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            PrintLine();
            PrintLine2(20);

            int result = Add(10, 20);
            Console.WriteLine(result);
        }
    }
}
