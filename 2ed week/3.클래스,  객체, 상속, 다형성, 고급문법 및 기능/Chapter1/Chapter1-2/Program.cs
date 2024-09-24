namespace Chapter1_2
{
    internal class Program
    {
        class Person
        {
            private string name;
            private int age;

            // 디폴트 생성자, 생성자를 따로 안만들어 줬다면 자동으로 만들어지는 생성자
            // 물론 오버로딩을 통해 다른 매개변수를 가지는 생성자를 만들어 줬다면 이건 자동으로 만들어지지 않음
            // 그래서 기본적으로 매개변수를 가지지 않은 생성자와 다른 오버로딩한 생성자를 둘 다 두고 싶다면 둘 다 만들어줘야한다.
            public Person()
            {
                name = "UnKnown";
                age = 0;
                Console.WriteLine("Person 객체 생성");
            }
            public Person(string newName, int newAge)
            {
                name = newName;
                age = newAge;
                Console.WriteLine("Person 객체 생성");
            }

            public void PrintInfo()
            {
                Console.WriteLine($"Name: {name}, Age: {age}");
            }
        }

        static void Main(string[] args)
        {
            Person person1 = new Person();
            Person person2 = new Person("John", 25);
            person2.PrintInfo();
        }
    }
}
