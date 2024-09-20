using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI; // UI ���� ��ɵ� �������� ���� ���

public class GameManager : MonoBehaviour
{
    //���ӸŴ����� ��Ҹ� �ٸ� ��ũ��Ʈ���� ����ϱ� ���� �̱����� ����ڴ�
    public static GameManager Instance;
    // �̷��� ���ӿ�����Ʈ�� �������ָ� ����Ƽ���� prefab�� ����� ������ �� �ְԵȴ�.
    public GameObject rain;
    public GameObject endPanel;

    // Text��� Ÿ���� �������� ���� ����� ����Ƽ���� ���ϴ� �ؽ�Ʈ�� ����� ������ �� �ְԵȴ�.
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
        // MakeRain�̶�� �Լ���, �����ϸ鼭 �ٷ� �����Ű��, 1�ʸ��� �ݺ������� �����Ų��.
        InvokeRepeating("MakeRain", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0f)
        {
            totalTime -= Time.deltaTime; //��� ������ �����ð��� ���� �� �ֵ��� ������ ��� �ð��� ����� ��
        }
        else
        {
            // totalTime�� -�� ���� �ʵ��� �Ѵ�
            totalTime = 0f;
            endPanel.SetActive(true);
            // Time�� ũ�⸦ 0���� ����ٴ� ���� ù �����Ӱ� ���� �����Ӱ��� �ð� ���̰� �������ٴ� ��
            // �� ������ �ð��� ���ߴ� ȿ���� ��
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
