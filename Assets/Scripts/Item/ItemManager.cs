using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public List<ItemData> inventory = new List<ItemData>();
    private Coroutine _activeEffect;

    public void UseItem(ItemData item)
    {
        if (_activeEffect != null)
            StopCoroutine(_activeEffect);
        _activeEffect = StartCoroutine(ApplyEffect(item));
    }

    private IEnumerator ApplyEffect(ItemData item)
    {
        var pc = FindObjectOfType<PlayerController>();
        float originalSpeed = pc.moveSpeed;
        float buffDuration = item.displayName == "Cake" ? 180f : item.duration;

        pc.moveSpeed += item.effectValue;
        yield return new WaitForSeconds(buffDuration);
        pc.moveSpeed = originalSpeed;

        _activeEffect = null;
    }
}
