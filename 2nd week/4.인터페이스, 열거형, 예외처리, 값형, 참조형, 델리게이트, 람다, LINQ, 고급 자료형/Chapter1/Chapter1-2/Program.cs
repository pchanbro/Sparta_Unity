namespace Chapter1_2
{
    internal class Program
    {
        public interface IUsable
        {
            void Use();
        }

        public class Item : IUsable
        {
            public string Name { get; set; } // 자동 프로퍼티, 프로퍼티의 역할과 필드의 역할을 같이 한다.

            public void Use()
            {
                Console.WriteLine("아이템 {0}을 사용했습니다.", Name);
            }
        }

        public class Player
        {
            // 매개변수를 Item item이 아니라 Interface인 IUsable item로 받는다.
            // 왜냐하면 Item 말고도 다른 아이템 클래스가 존재할 수 있는데
            // 그 클래스들은 보통 IUsable을 상속 받았을것이다.
            // 그런 다른 아이템들도 사용하기 위해 매개변수를 IUsable item로 받는다.
            public void UseItem(IUsable item) 
            {
                item.Use();
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            Item item = new Item() { Name = "Health Potion" };
            player.UseItem(item);
        }
    }
}
