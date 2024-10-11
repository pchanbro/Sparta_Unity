using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    // 기본 스탯과 추가 스탯들을 계산해서 최종 스탯을 계산하는 로직
    // 근데 지금은 그냥 기본스텟만

    [SerializeField] private CharacterStat baseStat;
    public CharacterStat CurrentStat { get; private set; }

    public List<CharacterStat> statModifiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        AttackSO attackSO = null;
        if (baseStat.attackSO != null)
        {
            attackSO = Instantiate(baseStat.attackSO);// 복사본
        }

        CurrentStat = new CharacterStat { attackSO = attackSO };
        // TODO : 지금은 기본 능력치만 적용되지만, 앞으로는 능력치 강화기능이 적용된다.
        CurrentStat.statsChangeType = baseStat.statsChangeType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;
    }
}