using static Chapter2.Program;

namespace Chapter2
{
    internal class Program
    {
        public class NegativeNumberException : Exception
        {
            public NegativeNumberException(string message) : base(message)
            {
            }
        }


        static void Main(string[] args)
        {
            try
            {
                int number = -10;
                if (number < 0)
                {
                    // 아래 코드는 일부러 예외 처리를 발생시킨 것!
                    throw new NegativeNumberException("음수는 처리할 수 없습니다.");
                }
            }
            catch (NegativeNumberException ex)
            {
                // 이 코드를 실행시켰을때 여기서 ex.Message로 받은게 "음수는 처리할 수 없습니다." 이거다
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("예외가 발생했습니다: " + ex.Message);
            }
        }
    }
}
