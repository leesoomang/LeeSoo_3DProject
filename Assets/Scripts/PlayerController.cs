using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	[Header("Movement Settings")]
	public float moveSpeed = 5f;
	public float jumpForce = 7f;

	private Rigidbody _rb;
	private Vector2 _moveInput;
	private bool _jumpPressed;

	void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		// 입력 처리
		if (_jumpPressed && IsGrounded())
		{
			_rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
		_jumpPressed = false;
	}

	void FixedUpdate()
	{
		// 이동 물리 처리
		Vector3 vel = new Vector3(_moveInput.x, 0, _moveInput.y) * moveSpeed;
		Vector3 target = new Vector3(vel.x, _rb.velocity.y, vel.z);
		_rb.velocity = target;
	}

	public void OnMove(InputValue value)
	{
		_moveInput = value.Get<Vector2>();
	}

	public void OnJump(InputValue value)
	{
		if (value.isPressed) _jumpPressed = true;
	}

	private bool IsGrounded()
	{
		// 바닥 충돌 체크 (간단 레이캐스트)
		return Physics.Raycast(transform.position, Vector3.down, 1.1f);
	}
}
