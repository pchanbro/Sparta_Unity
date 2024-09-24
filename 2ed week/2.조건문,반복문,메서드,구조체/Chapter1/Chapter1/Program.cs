namespace Chapter1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // if문 기초
            int playerScore = 80;

            if (playerScore >= 70)
            {
                Console.WriteLine("플레이어의 점수는 70점 이상입니다. 합격입니다!");
            }
            Console.WriteLine("프로그램이 종료됩니다.");

            // else문 기초
            int itemCount = 5;
            string itemName = "HP 포션";

            if (itemCount > 0)
            {
                Console.WriteLine($"보유한 {itemName}의 수량: {itemCount}");
            }
            else
            {
                Console.WriteLine($"보유한 {itemName}이 없습니다.");
            }

            Console.WriteLine();

            // else if 실습
            int score = 100;
            string playerRank = "";

            if (score >= 90)
            {
                playerRank = "Diamond";
            }
            else if (score >= 80)
            {
                playerRank = "Platinum";
            }
            else if (score >= 70)
            {
                playerRank = "Gold";
            }
            else if (score >= 60)
            {
                playerRank = "Silver";
            }
            else
            {
                playerRank = "Bronze";
            }

            Console.WriteLine("플레이어의 등급은 {0} 입니다.", playerRank);

            Console.WriteLine();

            // [코드스니펫] switch문 기초
            Console.WriteLine("게임을 시작합니다.");
            Console.WriteLine("1: 전사 / 2: 마법사 / 3: 궁수");
            Console.Write("직업을 선택하세요: ");
            string job = Console.ReadLine();

            switch (job) // 디버그 포인트 (옆에 누르던가 F9 누르던가)
            {
                case "1": // 지금 job으로 받아온건 문자열이기 때문에 case 뒤에도 "를 사용한 문자열로 보여준다.
                    Console.WriteLine("전사를 선택하셨습니다.");
                    break;
                case "2":
                    Console.WriteLine("마법사를 선택하셨습니다.");
                    break;
                case "3":
                    Console.WriteLine("궁수를 선택하셨습니다.");
                    break;
                default:
                    Console.WriteLine("올바른 값을 입력해주세요.");
                    break;
            }

            Console.WriteLine("게임을 종료합니다.");
        }
    }
}
