using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float fallDamageThreshold = 5f;     // �� �Ÿ� �̻� �������� ������
    public float fallDamagePerMeter = 10f;     // �ʰ� 1m�� ������

    private float _currentHealth;
    private float _lastGroundY;

    public static event Action<float, float> OnHealthChanged; // (current, max)

    void Start()
    {
        _currentHealth = maxHealth;
        _lastGroundY = transform.position.y;
        OnHealthChanged?.Invoke(_currentHealth, maxHealth);
    }

    void Update()
    {
        if (IsGrounded())
        {
            float drop = _lastGroundY - transform.position.y;
            if (drop > fallDamageThreshold)
            {
                float dmg = (drop - fallDamageThreshold) * fallDamagePerMeter;
                TakeDamage(dmg);
            }
            _lastGroundY = transform.position.y;
        }
    }

    public void TakeDamage(float amount)
    {
        _currentHealth = Mathf.Max(_currentHealth - amount, 0f);
        OnHealthChanged?.Invoke(_currentHealth, maxHealth);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
