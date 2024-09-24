namespace Chapter3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter your name: ");
            //string name = Console.ReadLine();
            //Console.WriteLine("Hello, {0}!", name);

            Console.Write("Enter two numbers: ");
            string input = Console.ReadLine();    // "10 20"과 같은 문자열을 입력받음

            string[] numbers = input.Split(' ');  // 문자열을 공백으로 구분하여 배열로 만듦
            // { "10", "20" }
            int num1 = int.Parse(numbers[0]);     // 첫 번째 값을 정수로 변환하여 저장, 형변환이랑은 다르다
            int num2 = int.Parse(numbers[1]);     // 두 번째 값을 정수로 변환하여 저장

            int sum = num1 + num2;                // 두 수를 더하여 결과를 계산

            Console.WriteLine("The sum of {0} and {1} is {2}.", num1, num2, sum);
        }
    }
}
