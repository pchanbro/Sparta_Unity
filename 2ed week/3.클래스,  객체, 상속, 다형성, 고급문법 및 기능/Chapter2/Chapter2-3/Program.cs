namespace Chapter2_3
{
    internal class Program
    {
        abstract class Shape
        {
            public abstract void Draw(); // 추상 클래스의 메소드는 상속받는 클래스에서 무조건 재정의 해줘야함
        }

        class Circle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing a Circle");
            }
        }

        class Square : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing a Square");
            }
        }

        class Triangle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Drawing a Triangle");
            }
        }

        static void Main(string[] args)
        {
            
            // Shape shape = new Shape(); Shape는 추상클래스이기 때문에 이렇게 만들 수 없다.
            List<Shape> list = new List<Shape>();
            list.Add(new Circle());
            list.Add(new Square());
            list.Add(new Triangle());

            foreach (Shape shape in list)
            {
                shape.Draw();
            }
        }
    }
}
