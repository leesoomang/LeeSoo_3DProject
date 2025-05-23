using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Item,
}
public enum ConsumableType
{
    Speed,
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "NewItem")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public ItemType type;
    public Sprite icon;
    public GameObject dropprefab;
    public float duration;
    public float effectValue;

}
