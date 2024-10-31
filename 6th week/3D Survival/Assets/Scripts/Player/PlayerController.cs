using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpForce;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook; // x의 회전범위
    public float maxXLook;
    private float camCurXRot; // InputAction에서 마우스 delta값 받아오는걸 여기에 넣어줌
    public float lookSensitivity; // 회전 민감도
    private Vector2 mouseDelta; // 프레임마다 마우스의 변화값

    public bool canLook = true;

    public Action inventory;

    private Rigidbody rigidbody; 

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서가 안보이도록 커서가 안보이는 상태로 설정
    }

    void FixedUpdate() // 물리 연산은 FixedUpdate에서 해주는게 좋다.
    {
        Move();
    }

    private void LateUpdate()
    {
        if(canLook)
        {
            CameraLook();
        }
    }

    void Move()
    {
        // 2차원과 3차원이 오가는 거라 헷갈릴 수 있음 주의
        // 지금은 w, s가 각각 Up, Down(화면상 위아래, y값 변화, 2차원)에 매핑되어 있으니 dir에선(3차원) forward에 y값을 곱함
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        // 실제 플레이어의 y값을 변경하면 캐릭터가 위아래로 움직이니 고정시켜준다.
        dir.y = rigidbody.velocity.y; // 점프했을때만 위아래로 움직이게 하기 위해 기존의 0 ~0.1정도의 값을 유지시켜 주는것이다.

        rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        // 마우스를 좌,우로 움직이면 mouseDelta의 x값이 바뀐다.
        // y축을 돌려줘야 좌우로 움직이므로 y축을 돌릴 땐 mouseDelta.x값을 사용한다.
        // 반대로 상,하로 회전하기 위해 x축을 돌려줘야 하므로 마우스y값을 x축 변화에 넣어줘야 한다.
        // 화면상 x,y,z축이 어떤 방향인지를 알면 이해하기 좋다.
        // 참고로 유니티의 Rotation값은 마우스 x,y 좌표에 대해 왼쪽 위를 기준으로 오른쪽이 +y, 아래쪽이 +x다.
        // 그와 반대로 mouseDelta.y값은 마우스를 위로 드래그 하면 -가 된다.
        // 그리고 += 으로 해주는 이유는 시야는 그 위치에서 추가로 더해줘야 하고 어차피 180도 넘어가면 -값으로 바뀐다.
        camCurXRot += mouseDelta.y * lookSensitivity;

        // 최소, 최댓값을 넘어가지 않게 최대,최소 값을 넘어가면 그 값을 반환하도록 한다.
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);

        // 상 하 회전은 카메라만 돌려준다.
        // 월드좌표가 아닌 로컬좌표로 돌려줘야 한다.
        // 몸이 아닌 얼굴만 위아래로 돌린다는 느낌
        // mouseDelta.y값은 마우스를 위로 드래그 하면 -가 되는데
        // 실제로 유니티에서 Transform의 Rotation값을 
        // -로 내리면 위를 보고 +로 하면 밑은 본다
        // 즉, 마우스 실제 동작과 보여주는게 값이 반대가 된다.
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0); 

        // 좌 우 회전은 캐릭터 자체를 돌려준다.
        // y축을 돌려줘야 좌우로 각이 움직이므로 마우스x값을 y축 변화에 넣어준다.
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0); // 좌, 우는 캐릭터 각도로 조절한다.
    }

    public void OnMove(InputAction.CallbackContext context) // CallbackContext 변수는 현재 상태를 받아올 수 있다.
    {
        // phase는 분기점이라 보자
        // InputActionPhase.Started는 키를 누르는 순간 한번만 작동
        // 키가 계속 눌린 뒤에도 값을 받아오도록 InputActionPhase.Performed 사용
        if (context.phase == InputActionPhase.Performed) 
        {
            curMovementInput = context.ReadValue<Vector2>(); // 값을 읽어오는 ReadValue 사용
        }
        else if(context.phase == InputActionPhase.Canceled) // 키가 떼졌을 때
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta =  context.ReadValue<Vector2>(); // 마우스는 계속 값이 유지되니 Phase 처리 할 필요가 없다.
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    // 캐릭터가 땅에 있는지 아닌지를 확인하기 위해선 Ray가 필요하다.
    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
        };

        for(int i = 0; i< rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            inventory?.Invoke();
            ToggleCursor();
        }
    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }
}
