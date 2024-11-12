﻿using System;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownRangeEnemyController : TopDownEnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRange = 15f;
    [SerializeField][Range(0f, 100f)] private float shootRange = 10f;

    private int layerMaskTarget;
    private int layerMaskLevel;

    protected override void Start()
    {
        base.Start();
        layerMaskTarget = stats.CurrentStat.attackSO.target;
        layerMaskLevel = LayerMask.NameToLayer("Level");
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        float distanceToTarget = DistanceToTarget();
        Vector2 directionToTarget = DirectionToTarget();

        UpdateEnemyState(distanceToTarget, directionToTarget);
    }

    private void UpdateEnemyState(float distanceToTarget, Vector2 directionToTarget)
    {
        IsAttacking = false;
        if (distanceToTarget < followRange)
        {
            CheckIfNear(distanceToTarget, directionToTarget);
        }
    }

    private void CheckIfNear(float distance, Vector2 direction)
    {
        if (distance <= shootRange)
        {
            TryShootAtTarget(direction);
        }
        else
        {
            CallMoveEvent(direction); // 사정거리 밖이지만 추적 범위 내에 있을 경우, 타겟 쪽으로 이동합니다.
        }
    }

    private void TryShootAtTarget(Vector2 direction)
    {
        // 몬스터 위치에서 direction 방향으로 레이를 발사합니다.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootRange, layerMaskTarget);

        // 벽에 맞은게 아니라 실제 플레이어에 맞았는지 확인합니다.
        if (hit.collider != null)
        {
            PerformAttackAction(direction);
        }
        else
        {
            CallMoveEvent(direction);
        }
    }

    private void PerformAttackAction(Vector2 direction)
    {
        CallLookEvent(direction);
        CallMoveEvent(Vector2.zero);
        IsAttacking = true;
    }
}