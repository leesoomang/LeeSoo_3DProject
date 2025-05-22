using UnityEngine;

public enum ItemType
{
    HealOverTime,
    SpeedBoost,
    // �ʿ信 ���� �߰�
}

[CreateAssetMenu(menuName = "Game/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    [TextArea] public string description;
    public ItemType type;
    public float effectValue;
    public float duration;   // ��
}
