namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] answer = new int[3];
            Random random = new Random();
            for (int i = 0; i < answer.Length; i++)
            {
                answer[i] = random.Next(1, 10);
            }

            int[] choices = new int[3];
            int correct = 0;

            while (correct != 3)
            {
                correct = 0;

                for (int i = 0; i < choices.Length; i++)
                {
                    Console.Write("{0}번 째 숫자를 입력하세요 (1 ~ 9) : ", i + 1);
                    choices[i] = int.Parse(Console.ReadLine());
                }

                for (int i = 0; i < answer.Length; i++)
                {
                    for (int j = 0; j < choices.Length; j++)
                    {
                        if (answer[i] == choices[j])
                        {
                            correct++;
                            break;
                        }
                    }
                }

                Console.WriteLine("{0}개의 숫자를 맞추셨습니다.", correct);
            }
            Console.WriteLine("게임 종료");
        }
    }
}
