using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    // 방향을 바꾸기 위한 용도의 변수 선언
    float direction = 0.05f;

    // SpriteRenderer의 flip을 쓰기 위해 우선 선언을 해주고 GetComponent를 통해 요소를 가져온다.
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // 모든 기기들이 1초에 60프레임만 변경하도록 설정
        renderer = GetComponent<SpriteRenderer>(); // renderer에 SpriteRenderer의 요소들이 담겨진다.
        Debug.Log("안녕");
    }

    // Update is called once per frame -> 프레임마다 불러오는것으로 컴퓨터 사양마다 차이가 발생할 수 있다. 
    // 근데 사양마다 차이가 생기면 좀 문제가 생긴다. 멀티플레이 경우 좋은 기기를 사용하는 사람이 훨씬 유리하다.
    // 그래서 이를 공평하게 만들어주도록 시작할 때 프레임을 맞춰준다.
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

        transform.position += Vector3.right * direction; // 매번 new Vector3(1.0f,0,0) 해주는 것보다 좀 더 편하게 쓰라고 만든거, left도 있음
        // 0.05f를 곱해주면 벡터의 각 요소 x,y,z에 각각 0.5f를 곱해준것과 같다.
    }
}
