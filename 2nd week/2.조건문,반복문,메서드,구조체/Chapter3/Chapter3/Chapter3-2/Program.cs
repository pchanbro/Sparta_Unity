namespace Chapter3_2
{
    internal class Program
    {
        // 근데 오버로딩에서 반환값과는 별개로 매개변수가 같으면
        // 예를들면 static long AddNumbers(int a, int b) 로 오버로딩 하면
        // 오류가 난다. return 타입이 long으로 다르긴 하지만 
        // 매개변수가 같기에 이건 불가능하다.
        // 즉, 오버로딩은 항상 매개변수가 달라야 한다.
        static int AddNumbers(int a, int b) 
        {
            return a + b;
        }
        static float AddNumbers(float a, float b)
        {
            return a + b;
        }

        static int AddNumbers(int a, int b, int c)
        {
            return a + b + c;
        }

        static void Main(string[] args)
        {
            int sum1 = AddNumbers(10, 30);
            float sum2 = AddNumbers(10.5f, 21.5f);
            int sum3 = AddNumbers(10, 20, 30);
        }
    }
}
