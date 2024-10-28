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
        // �̹� �ٸ� �ڷ�ƾ�� ���� ���̶��, ���� ���� ���� �ڷ�ƾ�� ����
        // ���� �ڷ�ƾ�� �ߺ� ������� �ʵ��� �ϰ�, ���ο� �ڷ�ƾ�� ������ �غ� �Ѵ�
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        image.enabled = true;
        image.color = new Color(1f, 100f / 255f, 100f / 255f);
        // FadeAway()��� �ڷ�ƾ�� �����Ͽ� �̹����� ������ ������� �۾��� ó��
        coroutine = StartCoroutine(FadeAway());
    }

    // ����Ƽ���� �ڷ�ƾ�� �����Ϸ��� IEnumerator Ÿ���� ��ȯ�ϴ� �޼��带 �����, StartCoroutine()�� ȣ���Ͽ� ����
    // coroutine Ȱ���غ��� -> IEnumerator �ʿ�
    private IEnumerator FadeAway()
    {
        float startAlpha = 0.3f;
        float a = startAlpha;

        while(a > 0)
        {
            a -= (startAlpha / flashSpeed) * Time.deltaTime;
            image.color = new Color(1f, 100f / 255f, 100f / 255f, a);
            yield return null; // ���� �����ӱ��� ���
        }

        image.enabled = false;
    }
}
