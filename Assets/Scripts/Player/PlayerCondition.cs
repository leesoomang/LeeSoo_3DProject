using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [Header("UI Condition ����")]
    [SerializeField] public UICondition uiCondition;

    // uiCondition�� �Ҵ�Ǿ� ������ Condition ��ȯ, �ƴϸ� null ��ȯ
    private Condition health => uiCondition != null ? uiCondition.health : null;


    void Awake()
    {
        if (uiCondition == null)
        {
            uiCondition = FindObjectOfType<UICondition>();
        }

        if (uiCondition == null)
        {
            Debug.LogError($"[{name}] UICondition�� ã�� �� �����ϴ�.", this);
            enabled = false;
        }
    }

    void Update()
    {
        // ü���� 0 ���Ϸ� �������� Die ȣ��
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
        // ��� ó�� ���� �߰�...
    }
}
