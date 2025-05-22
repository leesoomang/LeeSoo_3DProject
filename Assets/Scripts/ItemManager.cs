using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public List<ItemData> inventory = new List<ItemData>();
    private Coroutine _activeEffect;

    public void UseItem(ItemData item)
    {
        if (_activeEffect != null) StopCoroutine(_activeEffect);
        _activeEffect = StartCoroutine(ApplyEffect(item));
    }

    private IEnumerator ApplyEffect(ItemData item)
    {
        float elapsed = 0f;

        // ¿¹: HealOverTime
        if (item.type == ItemType.HealOverTime)
        {
            var hs = FindObjectOfType<HealthSystem>();
            while (elapsed < item.duration)
            {
                hs.TakeDamage(-item.effectValue * Time.deltaTime);
                elapsed += Time.deltaTime;
                yield return null;
            }
        }
        // ¿¹: SpeedBoost
        else if (item.type == ItemType.SpeedBoost)
        {
            var pc = FindObjectOfType<PlayerController>();
            pc.moveSpeed += item.effectValue;
            yield return new WaitForSeconds(item.duration);
            pc.moveSpeed -= item.effectValue;
        }

        _activeEffect = null;
    }
}
