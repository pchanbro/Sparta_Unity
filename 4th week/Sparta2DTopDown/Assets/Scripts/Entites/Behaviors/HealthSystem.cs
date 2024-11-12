using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = 0.5f;

    private CharacterStatHandler statHandler;
    private float timeSinceLastChange = float.MaxValue;
    private bool isAttacked = false;
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;

    public float CurrentHealth { get; private set; }

    public float MaxHealth => statHandler.CurrentStat.maxHealth;

    private void Awake()
    {
        statHandler =  GetComponent<CharacterStatHandler>();
    }
    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (isAttacked && timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                OnInvincibilityEnd?.Invoke();
                isAttacked = false;
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        // 무적 시간에는 체력이 달지 않음
        if (timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        timeSinceLastChange = 0f;
        CurrentHealth += change;
        // [최솟값을 0, 최댓값을 MaxHealth로 하는 구문]
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        // CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        // CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth; 와 같아요!

        if (CurrentHealth <= 0f)
        {
            CallDeath();
            return true;
        }

        if (change >= 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
            isAttacked = true;
        }


        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
