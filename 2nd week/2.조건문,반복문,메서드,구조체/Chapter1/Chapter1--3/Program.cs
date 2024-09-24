namespace Chapter1_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // for문
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            // while문
            int j = 0;
            while (j < 10)
            {
                Console.WriteLine(j);
                j++;
            }

            // 구구단 출력
            for (int k = 2; k <= 9; k++)
            {
                for (int m = 1; m <= 9; m++)
                {
                    Console.Write(k + " x " + m + " = " + (k * m) + "\t");
                }
                Console.WriteLine();
            }

            // break와 continue의 기초
            for (int i = 1; i <= 10; i++)
            {
                if (i % 3 == 0)
                {
                    continue; // 3의 배수인 경우 다음 숫자로 넘어감
                }

                Console.WriteLine(i);
                if (i == 7)
                {
                    break; // 7이 출력된 이후에는 반복문을 빠져나감
                }
            }


            // break와 continue의 예제
            int sum = 0;

            while (true) // 무한루프, for(;;)와 같다
            {
                Console.Write("숫자를 입력하세요: ");
                int input = int.Parse(Console.ReadLine());

                if (input == 0)
                {
                    Console.WriteLine("프로그램을 종료합니다.");
                    break;
                }

                if (input < 0)
                {
                    Console.WriteLine("음수는 무시합니다.");
                    continue;
                }

                sum += input;
                Console.WriteLine("현재까지의 합: " + sum);
            }

            Console.WriteLine("합계: " + sum);
        }
    }
}
