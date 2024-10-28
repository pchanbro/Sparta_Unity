using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public Image image;
    public float flashSpeed;

    private Coroutine coroutine;

    void Start()
    {
        CharacterManager.Instance.Player.condition.onTakeDamage += Flash;   
    }

    public void Flash()
    {
        // 이미 다른 코루틴이 실행 중이라면, 현재 실행 중인 코루틴을 중지
        // 같은 코루틴이 중복 실행되지 않도록 하고, 새로운 코루틴을 시작할 준비를 한다
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        image.enabled = true;
        image.color = new Color(1f, 100f / 255f, 100f / 255f);
        // FadeAway()라는 코루틴을 시작하여 이미지가 서서히 사라지는 작업을 처리
        coroutine = StartCoroutine(FadeAway());
    }

    // 유니티에서 코루틴을 실행하려면 IEnumerator 타입을 반환하는 메서드를 만들고, StartCoroutine()을 호출하여 시작
    // coroutine 활용해보자 -> IEnumerator 필요
    private IEnumerator FadeAway()
    {
        float startAlpha = 0.3f;
        float a = startAlpha;

        while(a > 0)
        {
            a -= (startAlpha / flashSpeed) * Time.deltaTime;
            image.color = new Color(1f, 100f / 255f, 100f / 255f, a);
            yield return null; // 다음 프레임까지 대기
        }

        image.enabled = false;
    }
}
