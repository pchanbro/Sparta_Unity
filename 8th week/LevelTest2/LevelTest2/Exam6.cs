using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTest2
{
    internal class Exam6
    {
    }

    public class MoneyManager : MonoBehaviour
    {
        public (A : static ) MoneyManager Instance;

    private int money = 0;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = (B : this );
            // 씬 간의 이동에도 파괴되지 않도록 처리합니다.
            (C : DontDestroyOnLoad )(gameObject);
        }

        public bool HasEnoughMoney(int amount)
        {
            return money >= amount;
        }

        public void ChangeMoney(int amount)
        {
            money += amount;
        }

        public string GetFormattedMoney()
        {
            return FormatMoney(money);
        }

        private string FormatMoney(int money)
        {
            // 음수가 아니라고 가정
            Debug.Assert(money >= 0, "너에게 돈을 빌려줄 사람은 없어.");

            if (money == 0)
            {
                return "0";
            }

            string[] units = { "", "만", "억" };
            int unitIndex = 0;
            string result = "";

            // --- ㉠ --- //
            // 답
            // int로 표현된 money, 금액을 나타내는 숫자를 units와 조합시켜 문자열 result(~억 ~만 ~)원으로 만드는 과정
            while (money > 0)
            {
                int unitValue = money % 10000;
                money /= 10000;

                if (unitValue > 0)
                {

                    result = unitValue.ToString() + units[unitIndex] + " " + result;
                }

                unitIndex++;
            }
            // --- ㉠ --- //

            return result.Trim();
        }
    }
}
