using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    // �⺻ ���Ȱ� �߰� ���ȵ��� ����ؼ� ���� ������ ����ϴ� ����
    // �ٵ� ������ �׳� �⺻���ݸ�

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
            attackSO = Instantiate(baseStat.attackSO);// ���纻
        }

        CurrentStat = new CharacterStat { attackSO = attackSO };
        // TODO : ������ �⺻ �ɷ�ġ�� ���������, �����δ� �ɷ�ġ ��ȭ����� ����ȴ�.
        CurrentStat.statsChangeType = baseStat.statsChangeType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;
    }
}