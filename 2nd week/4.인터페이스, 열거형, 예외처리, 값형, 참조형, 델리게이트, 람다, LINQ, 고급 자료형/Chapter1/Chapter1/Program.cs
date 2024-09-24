namespace Chapter1
{
    internal class Program
    {
        // 인터페이스 구현해보기
        public interface IMovable
        {
            void Move(int x, int y);
        }

        public class Player : IMovable // 여기서 이동해야 한다는 제약을 거는걸로 인터페이스를 상속받음
        {
            public void Move(int x, int y)
            {
                // 이동 구현
            }
        }

        public class Enemy : IMovable
        {
            public void Move(int x, int y)
            {
                // 이동 구현
            }
        }

        static void Main(string[] args)
        {
            // 실제로 생성한건 Player, Enemy지만 Imovable을 참조했다
            IMovable movableObject1 = new Player();
            IMovable movableObject2 = new Enemy();

            // Player와 Enemy는 서로 다른 클래스이고 다른 구현을 했지만 Interface를 통해 기능을 통합했다.
            movableObject1.Move(1, 2);
            movableObject2.Move(1, 9);
        }
    }
}
