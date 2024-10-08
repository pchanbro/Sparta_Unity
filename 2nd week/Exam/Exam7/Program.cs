namespace Exam7
{
    class Program
    {
        // 다음 코드의 출력 결과를 작성하고, 왜 그렇게 되는지 이유를 설명해주세요
        public class Unit
        {
            public virtual void Move()
            {
                Console.WriteLine("두발로 걷기");
            }

            public void Attack()
            {
                Console.WriteLine("Unit 공격");
            }
        }

        public class Marine : Unit
        {

        }

        public class Zergling : Unit
        {
            public override void Move()
            {
                Console.WriteLine("네발로 걷기");
            }
        }

        static void Main(string[] args)
        {
            Zergling zerg = new Zergling();
            zerg.Move();
        }
    }

    // 출력 결과 : 네발로 걷기
    // 이유 : Zergling의 상위 클래스 Unit에서 Move 함수를 virtual로 선언했다.
    // Zergling이 Unit을 상속받았고 Move 함수를 override 했기 때문에 
    // Zergling 객체 zerg의 zerg.Move()를 하게되면 Zergling클래스의 Move가 실행되어 "네발로 걷기"가 출력된다.

    // 만일
    // Unit zerg = new Zergling 했을 때 Move 함수를 virtual, override 해주지 않는다면
    // zerg.Move()의 결과로 Unit 클래스의 Move가 실행된다.
}
