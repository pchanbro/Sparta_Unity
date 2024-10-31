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
    public float minXLook; // x�� ȸ������
    public float maxXLook;
    private float camCurXRot; // InputAction���� ���콺 delta�� �޾ƿ��°� ���⿡ �־���
    public float lookSensitivity; // ȸ�� �ΰ���
    private Vector2 mouseDelta; // �����Ӹ��� ���콺�� ��ȭ��

    public bool canLook = true;

    public Action inventory;

    private Rigidbody rigidbody; 

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ���� �Ⱥ��̵��� Ŀ���� �Ⱥ��̴� ���·� ����
    }

    void FixedUpdate() // ���� ������ FixedUpdate���� ���ִ°� ����.
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
        // 2������ 3������ ������ �Ŷ� �򰥸� �� ���� ����
        // ������ w, s�� ���� Up, Down(ȭ��� ���Ʒ�, y�� ��ȭ, 2����)�� ���εǾ� ������ dir����(3����) forward�� y���� ����
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        // ���� �÷��̾��� y���� �����ϸ� ĳ���Ͱ� ���Ʒ��� �����̴� ���������ش�.
        dir.y = rigidbody.velocity.y; // ������������ ���Ʒ��� �����̰� �ϱ� ���� ������ 0 ~0.1������ ���� �������� �ִ°��̴�.

        rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        // ���콺�� ��,��� �����̸� mouseDelta�� x���� �ٲ��.
        // y���� ������� �¿�� �����̹Ƿ� y���� ���� �� mouseDelta.x���� ����Ѵ�.
        // �ݴ�� ��,�Ϸ� ȸ���ϱ� ���� x���� ������� �ϹǷ� ���콺y���� x�� ��ȭ�� �־���� �Ѵ�.
        // ȭ��� x,y,z���� � ���������� �˸� �����ϱ� ����.
        // ����� ����Ƽ�� Rotation���� ���콺 x,y ��ǥ�� ���� ���� ���� �������� �������� +y, �Ʒ����� +x��.
        // �׿� �ݴ�� mouseDelta.y���� ���콺�� ���� �巡�� �ϸ� -�� �ȴ�.
        // �׸��� += ���� ���ִ� ������ �þߴ� �� ��ġ���� �߰��� ������� �ϰ� ������ 180�� �Ѿ�� -������ �ٲ��.
        camCurXRot += mouseDelta.y * lookSensitivity;

        // �ּ�, �ִ��� �Ѿ�� �ʰ� �ִ�,�ּ� ���� �Ѿ�� �� ���� ��ȯ�ϵ��� �Ѵ�.
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);

        // �� �� ȸ���� ī�޶� �����ش�.
        // ������ǥ�� �ƴ� ������ǥ�� ������� �Ѵ�.
        // ���� �ƴ� �󱼸� ���Ʒ��� �����ٴ� ����
        // mouseDelta.y���� ���콺�� ���� �巡�� �ϸ� -�� �Ǵµ�
        // ������ ����Ƽ���� Transform�� Rotation���� 
        // -�� ������ ���� ���� +�� �ϸ� ���� ����
        // ��, ���콺 ���� ���۰� �����ִ°� ���� �ݴ밡 �ȴ�.
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0); 

        // �� �� ȸ���� ĳ���� ��ü�� �����ش�.
        // y���� ������� �¿�� ���� �����̹Ƿ� ���콺x���� y�� ��ȭ�� �־��ش�.
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0); // ��, ��� ĳ���� ������ �����Ѵ�.
    }

    public void OnMove(InputAction.CallbackContext context) // CallbackContext ������ ���� ���¸� �޾ƿ� �� �ִ�.
    {
        // phase�� �б����̶� ����
        // InputActionPhase.Started�� Ű�� ������ ���� �ѹ��� �۵�
        // Ű�� ��� ���� �ڿ��� ���� �޾ƿ����� InputActionPhase.Performed ���
        if (context.phase == InputActionPhase.Performed) 
        {
            curMovementInput = context.ReadValue<Vector2>(); // ���� �о���� ReadValue ���
        }
        else if(context.phase == InputActionPhase.Canceled) // Ű�� ������ ��
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta =  context.ReadValue<Vector2>(); // ���콺�� ��� ���� �����Ǵ� Phase ó�� �� �ʿ䰡 ����.
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    // ĳ���Ͱ� ���� �ִ��� �ƴ����� Ȯ���ϱ� ���ؼ� Ray�� �ʿ��ϴ�.
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
