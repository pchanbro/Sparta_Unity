namespace Chapter3
{
    internal class Program
    {
        delegate void MyDelegate(string message);

        static void Method1(string message)
        {
            Console.WriteLine("Method1 : " + message);
        }

        static void Method2(string message)
        {
            Console.WriteLine("Method2 : " + message);
        }
        static void Main(string[] args)
        {
            MyDelegate myDelegate = Method1;
            myDelegate += Method2;  // +를 통해 Method를 하나 더 연결할 수 있다.

            myDelegate("Hello!");  // 여기서 이건 Method1("Hello!"); Method2("Hello!"); 를 해준것과 같다.
        }
    }
}
