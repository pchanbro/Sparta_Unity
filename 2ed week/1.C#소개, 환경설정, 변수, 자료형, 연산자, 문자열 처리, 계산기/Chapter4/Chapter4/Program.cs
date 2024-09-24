namespace Chapter4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("산술연산자");
            int num1 = 10, num2 = 20;

            Console.WriteLine(num1 + num2);
            Console.WriteLine(num1 - num2);
            Console.WriteLine(num1 / num2);
            Console.WriteLine(num1 * num2);
            Console.WriteLine(num1 % num2);

            Console.WriteLine(5 % 2);

            Console.WriteLine();  //빈줄 출력

            Console.WriteLine("관계연산자");
            Console.WriteLine(num1 == num2);
            Console.WriteLine(num1 != num2);
            Console.WriteLine(num1 > num2);
            Console.WriteLine(num1 < num2);
            Console.WriteLine(num1 >= num2);
            Console.WriteLine(num1 <= num2);

            Console.WriteLine();
            Console.WriteLine("논리연산자");

            int num3 = 15;
            Console.WriteLine(0 <= num3 && num3 <= 20); // 0 ~ 20 의 수라면
            Console.WriteLine(0 > num3 || num3 > 20); // 0 ~ 20 외의 수라면

            Console.WriteLine( !(0 <= num3 && num3 <= 20));  // 0 ~ 20 외의 수라면

            Console.WriteLine();
        }
    }
}
