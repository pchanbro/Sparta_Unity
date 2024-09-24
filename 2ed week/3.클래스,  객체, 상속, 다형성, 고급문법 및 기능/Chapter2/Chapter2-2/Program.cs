namespace Chapter2_2
{
    internal class Program
    {
        public class Unit
        {
            public virtual void Move()  // 자식이 재정의를 했을 수 있다.
            {
                Console.WriteLine("두발로 걷기");
            }
            // virtual -> 실형태가 다를 수 있으니 실형태에 재정의가 되어있는지 확인하기
            // 만약 virtual 하지 않았다면 Unit 리스트의 Zergling 객체의 Move를 실행시키면
            // Unit의, 상위 클래스의 메소드가 실행된다.
            // 그러니까 객체 수가 너무 많아져서 각자의 클래스로 사용하기 보다는
            // 부모의 형태로 한 번에 처리하려고 할 때 virtual를 사용하는것

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
            public override void Move() // virtual한 상위 클래스의 메소드를 재정의 하기 위해 override 사용
            {
                Console.WriteLine("네발로 걷기");
            }
        }


        static void Main(string[] args)
        {
            //Marine marine = new Marine();
            //marine.Move();
            //marine.Attack();

            //Zergling zergling = new Zergling();
            //zergling.Move();
            //zergling.Attack();

            // Unit은 참조의 형태, Marine, Zergling 실형태
            List<Unit> list = new List<Unit>();
            list.Add(new Marine());
            list.Add(new Zergling());

            foreach(Unit unit in list)
            {
                unit.Move();
            }
        }
    }
}
