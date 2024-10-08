using System.Collections.Generic;

class Program
{
    // 다음 코드의 출력 결과를 작성하고, 왜 그렇게 되는지 이유를 설명해주세요.
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Pop();
        Console.WriteLine(stack.Pop());
        stack.Push(4);
        stack.Push(5);

        while (stack.Count > 0)
            Console.WriteLine(stack.Pop());
    }

    // 답 : 스택은 후입선출
    // 1) 스택에 1, 2, 3 을 순서대로 넣는다
    // 2) 3이 빠진다.
    // 3) 2가 빠지면서 출력된다.
    // 4) 스택에 1이 남아있는 상태에서 4, 5를 순서대로 넣는다.
    // 5) 나머지 전부 빠지면서 출력되는데 후입 선출이니까 5, 4, 1 순서대로 출력된다.
}
