using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

namespace LevelTest2
{
    internal class Exam5
    {

    }

    // CoroutineTest 컴포넌트가 부착된 게임 오브젝트가 활성화된 상태로 씬에 존재하고, 플레이 중 씬을 로드한 뒤로부터 10초의 시간이 흘렀다고 할 때,
    // 콘솔 창에 출력된 로그를 순서대로 쓰고, 그렇게 출력되는 이유를 설명하시오.

    public class CoroutineTest : MonoBehaviour
    {
        private Coroutine myCoroutine;
        private void Start()
        {
            StartTestCoroutine();
            Invoke("StartTestCoroutine", 1);
        }

        void StartTestCoroutine()
        {
            if (myCoroutine != null) StopCoroutine(myCoroutine);
            myCoroutine = StartCoroutine(TestCoroutine());
        }
        IEnumerator TestCoroutine()
        {
            Debug.Log("a");
            yield return null;
            Debug.Log("b");
            yield return new WaitForSeconds(3);
            Debug.Log("c");
        }
    }

    // 답 
    // abab
    // 1초에 a
    // 2초에 b 그리고 3초 대기
    // 6초에 a
    // 7초에 b 3초대기 하면 10초다
}
