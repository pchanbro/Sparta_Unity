namespace Chapter2
{
    internal class Program
    {

        // 부모 클래스
        public class Animal
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public void Eat()
            {
                Console.WriteLine("Animal is eating.");
            }

            public void Sleep()
            {
                Console.WriteLine("Animal is sleeping.");
            }
        }

        // 자식 클래스
        public class Dog : Animal
        {
            public void  Bark()
            {
                Console.WriteLine("Dog is bark");
            }
        }

        public class Cat : Animal
        {
            public void Meow()
            {
                Console.WriteLine("Cat is meow");
            }

            public void Sleep() // 부모의 Sleep보다 이걸 우선시해서 실행시킴
            {
                Console.WriteLine("Cat Sleep");
            }
        }


        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Name = "Bobby";
            dog.Age = 3;

            dog.Eat();
            dog.Sleep();
            dog.Bark();

            Cat cat = new Cat();
            cat.Name = "Kkami";
            cat.Age = 10;

            cat.Eat();
            cat.Sleep();
            cat.Meow();
        }
    }
}
