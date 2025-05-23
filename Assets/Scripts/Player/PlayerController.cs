using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpPower;
    private Vector2 curMovementInput;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;    // �ν����Ϳ� �Ҵ����� �ʾƵ�, Awake���� �ڵ� ����
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        // cameraContainer�� �Ҵ���� �ʾ����� Main Camera�� ã�� �ڵ� �Ҵ�
        if (cameraContainer == null)
        {
            if (Camera.main != null)
            {
                cameraContainer = Camera.main.transform;
            }
            else
            {
                Debug.LogError("PlayerController: cameraContainer�� ����ְ�, Main Camera �±׵� �����ϴ�.");
            }
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
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
        dir.y = _rigidbody.velocity.y;
        _rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);

        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        curMovementInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }
    private bool _isGrounded;
    private bool IsGrounded()
    {
        return _isGrounded;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((groundLayerMask.value & (1 << collision.gameObject.layer)) != 0)
            _isGrounded = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if ((groundLayerMask.value & (1 << collision.gameObject.layer)) != 0)
            _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((groundLayerMask.value & (1 << collision.gameObject.layer)) != 0)
            _isGrounded = false;
    }

}
