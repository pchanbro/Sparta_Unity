namespace Chapter3_2
{
    internal class Program
    {
        // out 키워드 사용 예시
        static void Divide(int a, int b, out int quotient, out int remainder)
        {
            // out 매개변수는 함수 안에서 뭔가를 대입 해줘야 함 아니면 실행 안됨
            // 이렇게 초기화 해주면 받았던 값들이 바뀐채로 돌아감
            // return 해준다고 볼 수 있다.
            quotient = a / b;
            remainder = a % b;
        }

        // ref 키워드 사용 예시
        static void Swap(ref int a, ref int b)
        {
            // ref 매개변수는 굳이 뭔가를 대입해주지 않아도 함수 실행 가능
            int temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            int quotient, remainder;
            Divide(7, 3, out quotient, out remainder);
            Console.WriteLine($"{quotient}, {remainder}");

            int x = 1, y = 2;
            Swap(ref x, ref y);
            Console.WriteLine($"{x}, {y}");


        }
    }
}
