using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private string playerTag = "Player";

    public Transform Player { get; private set; }

    public ObjectPool ObjectPool {get; private set; }

    private void Awake()
    {
        //if(Instance != null) Destroy(gameObject);
        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
        ObjectPool = GetComponent<ObjectPool>();
    }
}
