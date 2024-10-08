namespace Exam5
{
    // 계속해서 정수를 입력받아 홀수인지 짝수인지 구분해주는 프로그램을 작성해보세요.
    // 정수가 아닌 데이터를 입력받으면 프로그램이 종료되도록 만들어보세요.
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("숫자를 입력하세요.");
                string answer = Console.ReadLine() ?? "0";

                bool isSuccess = int.TryParse(answer, out int result);

                if(isSuccess)
                {
                    if(result % 2 == 0)
                    {
                        Console.WriteLine("짝수입니다.");
                    }
                    else
                    {
                        Console.WriteLine("홀수입니다.");
                    }
                }
                else
                {
                    break;
                }

                // TODO : 입력받은 정수가 홀수인지 짝수인지 구분하는 코드 작성하기

                ///////////////////////////////////////////////////
            }
        }
    }
}
