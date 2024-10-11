﻿using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{ 
    // 실제로 이동이 일어날 컴포넌트

    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private CharacterStatHandler characterStatHandler;

    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        // 여기에는 주로 내 컴포넌트 안에서 끝나는 내용 작성

        // controller랑 TopdownMovement랑 같은 게임오브젝트 안에 있다라는 가정
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        characterStatHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        // FixedUpdate는 물리업데이트 관련
        // rigidbody의 값을 바꾸니까 FixedUpdate
        ApplyMovement(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * characterStatHandler.CurrentStat.speed;
        movementRigidbody.velocity = direction;
    }
}
