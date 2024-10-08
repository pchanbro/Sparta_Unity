namespace Exam4
{
    // 다음 코드의 출력 결과를 작성하고, x의 값이 순서대로 어떻게 변화하는지 작성해주세요.
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            int y = 3;

            x += x * ++y;

            Console.WriteLine(x++);
        }
    }

    // 답
    // 출력 : 10 
    // 과정 :
    // 1) x += 2 * ++3 ( 우항에 x = 2, y = 3 대입)
    // 2) x += 2 * 4 (y값 수치 +1)
    // 3) x = 2 + (2 * 4) ( x의 기존값에 우항을 더해주기)
    // 4) x = 10
    // 5) 10 출력
    // 6) x++ -> x = 11

}
