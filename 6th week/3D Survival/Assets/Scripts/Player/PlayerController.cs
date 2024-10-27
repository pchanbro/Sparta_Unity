using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpPower;
    private Vector2 curMovementInput;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook; // x의 회전범위
    public float maxXLook;
    private float camCurXRot; // InputAction에서 마우스 delta값 받아오는걸 여기에 넣어줌
    public float lookSensitivity; // 회전 민감도
    private Vector2 mouseDelta;

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
        CameraLook();
    }

    void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rigidbody.velocity.y; // 점프했을때만 위아래로 움직이게 하기 위해 기존의 0 ~0.1정도의 값을 유지시켜 주는것이다.

        rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        // 마우스를 좌,우로 움직이면 mouseDelta의 x값이 바뀐다.
        // y축을 돌려줘야 좌우로 움직이므로 y값을 넣어줘야 한다.
        camCurXRot += mouseDelta.y * lookSensitivity;

        // 최소, 최댓값을 넘어가지 않게 최대,최소 값을 넘어가면 그 값을 반환하도록 한다.
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);

        // 월드좌표가 아닌 로컬좌표로 돌려줘야 한다.
        // mouseDelta.y값은 마우스를 아래로 드래그 하면 -가 되는데
        // 실제로 유니티에서 Transform의 Rotation값을 
        // -로 내리면 위를 보고 +로 하면 밑은 본다
        // 즉, 마우스 실제 동작과 보여주는게 값이 반대가 된다.
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0); 

        // 이것도 x축을 돌려줘야 위아래로 각이 움직이므로 x값을 넣어준다.
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0); // 위, 아래는 캐릭터 각도로 조절한다.
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
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
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
}
