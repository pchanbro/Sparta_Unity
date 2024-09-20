using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    // ������ �ٲٱ� ���� �뵵�� ���� ����
    float direction = 0.05f;

    // SpriteRenderer�� flip�� ���� ���� �켱 ������ ���ְ� GetComponent�� ���� ��Ҹ� �����´�.
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // ��� ������ 1�ʿ� 60�����Ӹ� �����ϵ��� ����
        renderer = GetComponent<SpriteRenderer>(); // renderer�� SpriteRenderer�� ��ҵ��� �������.
        Debug.Log("�ȳ�");
    }

    // Update is called once per frame -> �����Ӹ��� �ҷ����°����� ��ǻ�� ��縶�� ���̰� �߻��� �� �ִ�. 
    // �ٵ� ��縶�� ���̰� ����� �� ������ �����. ��Ƽ�÷��� ��� ���� ��⸦ ����ϴ� ����� �ξ� �����ϴ�.
    // �׷��� �̸� �����ϰ� ������ֵ��� ������ �� �������� �����ش�.
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            direction *= -1;
            renderer.flipX = !renderer.flipX;
        }

        if (transform.position.x > 2.6f)
        {
            renderer.flipX = true;
            direction = -0.05f;
        }

        if (transform.position.x < -2.6f)
        {
            renderer.flipX = false;
            direction = 0.05f;
        }

        transform.position += Vector3.right * direction; // �Ź� new Vector3(1.0f,0,0) ���ִ� �ͺ��� �� �� ���ϰ� ����� �����, left�� ����
        // 0.05f�� �����ָ� ������ �� ��� x,y,z�� ���� 0.5f�� �����ذͰ� ����.
    }
}
