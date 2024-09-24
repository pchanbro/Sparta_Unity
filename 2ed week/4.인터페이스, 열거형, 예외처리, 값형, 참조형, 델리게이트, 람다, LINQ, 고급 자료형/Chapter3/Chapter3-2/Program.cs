namespace Chapter3_2
{
    internal class Program
    {
        // Func를 사용하여 두 개의 정수를 더하는 메서드
        static int Add(int x, int y)
        {
            return x + y;
        }

        // Action을 사용하여 문자열을 출력하는 메서드
        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }


        static void Main(string[] args)
        {
            // Func를 이용한 메서드 호출
            Func<int, int, int> addFunc = Add;
            int result = addFunc(3, 5);
            Console.WriteLine("결과: " + result);

            // Action을 이용한 메서드 호출
            Action<string> printAction = PrintMessage;
            printAction("Hello, World!");
        }
    }
}
