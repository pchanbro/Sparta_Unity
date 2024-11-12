using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;
    protected override void Awake()
    {
        base.Awake();
        camera = Camera.main; // mainCamera태그가 붙어있는 카메라를 가져온다.
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);

        //실제 움직이는 처리는 여기서 하는게 아니라 PlayerMovement에서 함
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        // 모니터 상의 마우스 좌표를 게임 월드의 좌표로 받아와 그 위치와 캐릭터의 위치의 차이로 방향을 만든다.
        // 그걸 통해 캐릭터의 각도, 방향 변화를 캐릭터와 마우스의 위치 차에 따라 발생시킨다.
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= .9f)
        // Vector 값을 실수로 변환
        {
            CallLookEvent(newAim);
        }
    }

    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
        Debug.Log("OnFire" + value.ToString());
    }
}
