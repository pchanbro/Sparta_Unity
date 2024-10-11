using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    protected bool IsAttacking;

    private float timeSinceLastAttack = float.MaxValue;

    // protected ������Ƽ�� �� ���� : ���� �ٲٰ� ������ �������°� �� ��ӹ޴� Ŭ�����鵵 �� �� �ְ�
    protected CharacterStatHandler stats {  get; private set; }

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatHandler>(); // ���� ���� ������Ʈ�� �־�� ��
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if(timeSinceLastAttack <= stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if (IsAttacking && timeSinceLastAttack > stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent(stats.CurrentStat.attackSO);
        }
    }


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. �ϸ� ������ ���� ������ ���� ->�����ϰ� ����
    }

    public void CallLookEvent(Vector2 director)
    {
        OnLookEvent?.Invoke(director);
    }

    private void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
