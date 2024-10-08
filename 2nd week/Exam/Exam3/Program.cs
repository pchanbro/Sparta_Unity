namespace Exam3
{
    // Area 함수를 Main에서 쓸 수 없는 이유를 설명해라
    class Square
    {
        float width;
        float height;

        public float Area() { return width * height; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Square box = new Square();
            Console.WriteLine(box.Area());
        }
    }

    // 잘못된 점 
    // Square의 클래스의 함수 Area의 접근 제한자가 private이기 때문에 발생하는 오류이다
    // Area의 접근 제한자를 public로 해주면 오류가 발생하지 않는다.\
    // 추가적으로 이대로 실행하면 width와 height에 값이 0씩 들어있으니 초기화를 해주던가, 값을 바꾸는 일을 해줘야 한다.
}
