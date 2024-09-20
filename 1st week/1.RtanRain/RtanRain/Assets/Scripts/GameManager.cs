using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI; // UI 관련 기능들 가져오기 위해 사용

public class GameManager : MonoBehaviour
{
    //게임매니저의 요소를 다른 스크립트에서 사용하기 위해 싱글톤을 만들겠다
    public static GameManager Instance;
    // 이렇게 게임오브젝트를 선언해주면 유니티에서 prefab을 끌어다 가져올 수 있게된다.
    public GameObject rain;
    public GameObject endPanel;

    // Text라는 타입을 가져오기 위해 만든다 유니티에서 원하는 텍스트를 끌어다 가져올 수 있게된다.
    public Text totalScoreTxt;
    public Text timeTxt;

    int totalScore;

    float totalTime = 30.0f;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        // MakeRain이라는 함수를, 시작하면서 바로 실행시키고, 1초마다 반복적으로 실행시킨다.
        InvokeRepeating("MakeRain", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0f)
        {
            totalTime -= Time.deltaTime; //모든 기기들이 같은시간을 가질 수 있도록 프레임 대비 시간을 맞춰둔 것
        }
        else
        {
            // totalTime이 -가 되지 않도록 한다
            totalTime = 0f;
            endPanel.SetActive(true);
            // Time의 크기를 0으로 만든다는 것은 첫 프레임과 다음 프레임과의 시간 차이가 없어진다는 것
            // 즉 게임의 시간이 멈추는 효과를 줌
            Time.timeScale = 0f;
        }
        timeTxt.text = totalTime.ToString("N2");
    }


    void MakeRain()
    {
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        if (totalScore < 0)
        {
            totalScore = 0;
        }
        totalScoreTxt.text = totalScore.ToString();
    }
}
