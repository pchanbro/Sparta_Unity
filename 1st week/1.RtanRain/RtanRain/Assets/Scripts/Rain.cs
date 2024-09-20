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

        float x = Random.Range(-2.4f, 2.4f); // 범위를 실수로 써주면 실수가 나오고
        float y = Random.Range(3.0f, 5.0f);

        transform.position = new Vector3(x, y, 0);

        int type = Random.Range(1, 5); // 범위를 정수로 써주면 정수로 나온다.

        if(type == 1)
        {
            size = 0.8f;
            score = 1;
            // 칼라값은 float이며 최대값으로 나눠줘야한다. 1f의 경우는 255라 보면 된다.
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

        // 크기 조절
        transform.localScale = new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 충돌작용은 oncollisionEnter에 작성해야한다.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //충돌된 물체의 정보는 collision에 들어간다
        if (collision.gameObject.name == "Ground")
        //if (collision.gameObject.CompareTag("Ground"))를 통해
        //Unity에서 태그 설정을 하고 그 태그와 비교해서 조건을 짤 수도 있다.
        {
            // 여기서 Destroy(collision.gameObject);을 하면 이 코드를 가진 오브젝트가 아닌 부딪힌 오브젝트가 사라진다.
            // 지금 이 게임의 경우 바닥이 사라지는 상황이 발생했음
            Destroy(this.gameObject);
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }
}
