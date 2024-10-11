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

    // protected 프로퍼티를 한 이유 : 나만 바꾸고 싶지만 가져가는건 내 상속받는 클래스들도 볼 수 있게
    protected CharacterStatHandler stats {  get; private set; }

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatHandler>(); // 같은 게임 오브젝트에 있어야 함
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
        OnMoveEvent?.Invoke(direction); // ?. 하면 없으면 말고 있으면 실행 ->안전하게 실행
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
