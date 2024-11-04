using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LevelTest2
{
    internal class Exam3
    {
    }

    public class Skill : MonoBehaviour
    {
        private Image remainGaugeBar;
        private TextMeshProUGUI remainText;

        private int remainSkillCnt; // 현재 남은 스킬 사용 가능 횟수
        private readonly int maxSkillCnt = 5; // 최대 스킬 사용 가능 횟수

        private void Awake()
        {
            remainSkillCnt = maxSkillCnt;

            //구성을 단순화하기 위해 이렇게 초기화했습니다. GetChild를 활용해서 초기화하는 방법은 권장되지 않습니다.
            remainGaugeBar = transform.GetChild(0).GetComponent<Image>();
            remainText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            SetSkillUI();
        }

        public void UseSkill()
        {
            if (remainSkillCnt <= 0) return;

            Debug.Log("스킬을 사용했다.");
            remainSkillCnt--;
            SetSkillUI();
        }

        void SetSkillUI()
        {
            //문제 3번 스킬의 남은 사용 가능 횟수에 따라 다음과 같이 게이지 바 이미지, 텍스트를 조정하는 SetSkillUI 메서드를 구현하시오.
            //TODO
            //remainGaugeBar, remainText을 활용할 것
            remainGaugeBar.fillAmount = (float)remainSkillCnt / maxSkillCnt;
            remainText.text = $"{remainSkillCnt} / {maxSkillCnt}";

        }
    }
}