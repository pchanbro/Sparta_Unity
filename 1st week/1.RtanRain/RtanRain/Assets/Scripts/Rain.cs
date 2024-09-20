using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 1.0f;
    int score = 1;

    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        float x = Random.Range(-2.4f, 2.4f); // ������ �Ǽ��� ���ָ� �Ǽ��� ������
        float y = Random.Range(3.0f, 5.0f);

        transform.position = new Vector3(x, y, 0);

        int type = Random.Range(1, 5); // ������ ������ ���ָ� ������ ���´�.

        if(type == 1)
        {
            size = 0.8f;
            score = 1;
            // Į���� float�̸� �ִ밪���� ��������Ѵ�. 1f�� ���� 255�� ���� �ȴ�.
            renderer.color = new Color(100 / 255f, 100 / 255f, 1f, 1f); 
        }
        else if(type == 2)
        {
            size = 1.0f;
            score = 2;
            renderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
        }
        else if(type == 3)
        {
            size = 1.2f;
            score = 3;
            renderer.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);
        }
        else if (type == 4)
        {
            size = 0.8f;
            score = -5;
            renderer.color = new Color(1f, 100 / 255f, 1f, 1f);
        }

        // ũ�� ����
        transform.localScale = new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �浹�ۿ��� oncollisionEnter�� �ۼ��ؾ��Ѵ�.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�浹�� ��ü�� ������ collision�� ����
        if (collision.gameObject.name == "Ground")
        //if (collision.gameObject.CompareTag("Ground"))�� ����
        //Unity���� �±� ������ �ϰ� �� �±׿� ���ؼ� ������ © ���� �ִ�.
        {
            // ���⼭ Destroy(collision.gameObject);�� �ϸ� �� �ڵ带 ���� ������Ʈ�� �ƴ� �ε��� ������Ʈ�� �������.
            // ���� �� ������ ��� �ٴ��� ������� ��Ȳ�� �߻�����
            Destroy(this.gameObject);
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }
}
