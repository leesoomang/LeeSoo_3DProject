using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [Header("UI Condition 참조")]
    [SerializeField] public UICondition uiCondition;

    // uiCondition이 할당되어 있으면 Condition 반환, 아니면 null 반환
    private Condition health => uiCondition != null ? uiCondition.health : null;


    void Awake()
    {
        if (uiCondition == null)
        {
            uiCondition = FindObjectOfType<UICondition>();
        }

        if (uiCondition == null)
        {
            Debug.LogError($"[{name}] UICondition을 찾을 수 없습니다.", this);
            enabled = false;
        }
    }

    void Update()
    {
        // 체력이 0 이하로 떨어지면 Die 호출
        if (health != null && health.curValue <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (health != null)
            health.Add(amount);
    }

    private void Die()
    {
        Debug.Log("Die");
        // 사망 처리 로직 추가...
    }
}
