namespace homework_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 사용자로부터 두 수를 입력받아 사칙연산 하기
            Console.Write("첫 번째 숫자를 입력하세요 : ");
            string str1 = Console.ReadLine();
            int num1 = int.Parse(str1);

            Console.Write("두 번째 숫자를 입력하세요 : ");
            string str2 = Console.ReadLine();
            int num2 = int.Parse(str2);

            Console.WriteLine("{0}, {1}",num1, num2);

            Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 + num2);
            Console.WriteLine("{0} - {1} = {2}", num1, num2, num1 - num2);
            Console.WriteLine("{0} * {1} = {2}", num1, num2, num1 * num2);
            Console.WriteLine("{0} / {1} = {2}", num1, num2, num1 / num2);
            Console.WriteLine("{0} % {1} = {2}", num1, num2, num1 % num2);

            // 섭씨온도를 화씨온도로 변환하는 프로그램
            Console.Write("섭씨온도를 입력하세요 : ");
            string str3 = Console.ReadLine();
            float num3 = float.Parse(str3);
            float num4 = num3 * 1.8f + 32.0f;
            Console.WriteLine("섭씨{0}도 = 화씨{1}도", num3, num4);

            // BMI 계산기
            Console.Write("키(cm)를 입력하세요 : ");
            string str5 = Console.ReadLine();
            float num5 = float.Parse(str5);

            Console.Write("몸무게(kg)를 입력하세요 : ");
            string str6 = Console.ReadLine();
            float num6 = float.Parse(str6);

            float bmi = num6 / ((num5 / 100) * (num5 / 100));
            Console.WriteLine("당신의 BMI : {0}", bmi);
        }
    }
}
