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
                // new WaitForSeconds�� GC�� ���ϰ� �ϱ� ���� ĳ���ϱ⵵ �մϴ�.
                yield return new WaitForSeconds(2f);

                ProcessWaveConditions();

                // yield return Coroutine���� ���� �ڷ�ƾ�� ���� ������ ��ٸ� �� �־��.
                // ��ø �ڷ�ƾ(Nested Coroutine)�̶�� �մϴ�.
                yield return StartCoroutine(SpawnEnemiesInWave());

                currentWaveIndex++;
            }

            // yield return null�� 1������ �ڶ�� �ǹ̿���!
            yield return null;
        }
    }

    void ProcessWaveConditions()
    {
        // % �� ������ ��������?
        // ������ ���� ���� ���ǹ��� �־, �ֱ⼺�� �ִ� ��� Ȱ���ϱ⵵ �ؿ�.

        // 20 ������������ �̺�Ʈ�� �߻��ؿ�.
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
        // ������ ���� OnEnemyDeath�� ����ؿ�.
        enemy.GetComponent<HealthSystem>().OnDeath += OnEnemyDeath;
        currentSpawnCount++;
    }

    // ������ �� �ִ� ���� �þ�� ����, �ִ��� ���� �ʾƿ�.
    void IncreaseSpawnPositions()
    {
        // ���׿����� ����Ͻ���? (���� ? ������ ���� �� : ������ ������ ��)ó�� ������ �ۼ��ſ�!
        waveSpawnPosCount = waveSpawnPosCount + 1 > spawnPositions.Count ? waveSpawnPosCount : waveSpawnPosCount + 1;
        waveSpawnCount = 0;
    }

    void IncreaseWaveSpawnCount()
    {
        waveSpawnCount += 1;
    }


    private void UpgradeStatInit()
    {
        Debug.Log("UpgradeStatInit ȣ��");
    }

    private void RandomUpgrade()
    {
        Debug.Log("RandomUpgrade ȣ��");

    }

    private void CreateReward()
    {
        Debug.Log("CreateReward ȣ��");
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
        // 1���̺���� ���� �� �ֵ��� 1�� �������.
        waveText.text = (currentWaveIndex + 1).ToString();
        // waveText.text = $"{currentWaveIndex + 1}"; �� �ص� �ȴ�. �̰� �ٷ� ���� ���ڿ�
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