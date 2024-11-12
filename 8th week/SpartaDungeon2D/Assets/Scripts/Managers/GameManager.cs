using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Transform Player { get; private set; }
    public ObjectPool ObjectPool { get; private set; }
    public ParticleSystem EffectParticle;

    [SerializeField] private string playerTag = "Player";

    private HealthSystem playerHealthSystem;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private Slider hpGaugeSlider;
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private int currentWaveIndex = 0;
    private int currentSpawnCount = 0;
    private int waveSpawnCount = 0;
    private int waveSpawnPosCount = 0;

    public float spawnInterval = .5f;
    public List<GameObject> enemyPrefebs = new List<GameObject>();

    [SerializeField] private Transform spawnPositionsRoot;
    private List<Transform> spawnPositions = new List<Transform>();

    private void Awake()
    {
        Instance = this;
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;

        ObjectPool = GetComponent<ObjectPool>();
        EffectParticle = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();

        playerHealthSystem = Player.GetComponent<HealthSystem>();
        playerHealthSystem.OnDamage += UpdateHealthUI;
        playerHealthSystem.OnHeal += UpdateHealthUI;
        playerHealthSystem.OnDeath += GameOver;

        for(int i = 0; i < spawnPositionsRoot.childCount; i++)
        {
            spawnPositions.Add(spawnPositionsRoot.GetChild(i));
        }
    }

    private void Start()
    {
        StartCoroutine(StartNextWave());
    }

    IEnumerator StartNextWave()
    {
        while (true)
        {
            if (currentSpawnCount == 0)
            {
                UpdateWaveUI();
                // new WaitForSeconds를 GC를 피하게 하기 위해 캐싱하기도 합니다.
                yield return new WaitForSeconds(2f);

                ProcessWaveConditions();

                // yield return Coroutine으로 하위 코루틴이 끝날 때까지 기다릴 수 있어요.
                // 중첩 코루틴(Nested Coroutine)이라고 합니다.
                yield return StartCoroutine(SpawnEnemiesInWave());

                currentWaveIndex++;
            }

            // yield return null은 1프레임 뒤라는 의미에요!
            yield return null;
        }
    }

    void ProcessWaveConditions()
    {
        // % 는 나머지 연산자죠?
        // 나머지 값에 따라 조건문을 주어서, 주기성이 있는 대상에 활용하기도 해요.

        // 20 스테이지마다 이벤트가 발생해요.
        if (currentWaveIndex % 20 == 0)
        {
            RandomUpgrade();
        }

        if (currentWaveIndex % 10 == 0)
        {
            IncreaseSpawnPositions();
        }

        if (currentWaveIndex % 5 == 0)
        {
            CreateReward();
        }

        if (currentWaveIndex % 3 == 0)
        {
            IncreaseWaveSpawnCount();
        }
    }

    IEnumerator SpawnEnemiesInWave()
    {
        for (int i = 0; i < waveSpawnPosCount; i++)
        {
            int posIdx = Random.Range(0, spawnPositions.Count);
            for (int j = 0; j < waveSpawnCount; j++)
            {
                SpawnEnemyAtPosition(posIdx);
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    void SpawnEnemyAtPosition(int posIdx)
    {
        int prefabIdx = Random.Range(0, enemyPrefebs.Count);
        GameObject enemy = Instantiate(enemyPrefebs[prefabIdx], spawnPositions[posIdx].position, Quaternion.identity);
        // 생성한 적에 OnEnemyDeath를 등록해요.
        enemy.GetComponent<HealthSystem>().OnDeath += OnEnemyDeath;
        currentSpawnCount++;
    }

    // 생성될 수 있는 곳이 늘어나는 로직, 최댓값을 넘지 않아요.
    void IncreaseSpawnPositions()
    {
        // 삼항연산자 기억하시죠? (조건 ? 조건이 참일 때 : 조건이 거짓일 때)처럼 구문이 작성돼요!
        waveSpawnPosCount = waveSpawnPosCount + 1 > spawnPositions.Count ? waveSpawnPosCount : waveSpawnPosCount + 1;
        waveSpawnCount = 0;
    }

    void IncreaseWaveSpawnCount()
    {
        waveSpawnCount += 1;
    }


    private void UpgradeStatInit()
    {
        Debug.Log("UpgradeStatInit 호출");
    }

    private void RandomUpgrade()
    {
        Debug.Log("RandomUpgrade 호출");

    }

    private void CreateReward()
    {
        Debug.Log("CreateReward 호출");
    }

    private void OnEnemyDeath()
    {
        currentSpawnCount--;
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    private void UpdateHealthUI()
    {
        hpGaugeSlider.value = playerHealthSystem.CurrentHealth / playerHealthSystem.MaxHealth;
    }

    private void UpdateWaveUI()
    {
        // 1웨이브부터 나올 수 있도록 1을 더해줘요.
        waveText.text = (currentWaveIndex + 1).ToString();
        // waveText.text = $"{currentWaveIndex + 1}"; 로 해도 된다. 이게 바로 보간 문자열
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}