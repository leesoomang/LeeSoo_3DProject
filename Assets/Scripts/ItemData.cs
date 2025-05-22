using UnityEngine;

public enum ItemType
{
    HealOverTime,
    SpeedBoost,
    // 필요에 따라 추가
}

[CreateAssetMenu(menuName = "Game/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    [TextArea] public string description;
    public ItemType type;
    public float effectValue;
    public float duration;   // 초
}
