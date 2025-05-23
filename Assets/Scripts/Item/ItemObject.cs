using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Oninteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData Data;

    public void Oninteract()
    {
        CharacterManager.Instance.Player.itemData = Data;
        CharacterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }
}


