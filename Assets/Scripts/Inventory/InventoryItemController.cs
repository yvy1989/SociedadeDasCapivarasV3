using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

    public Button RemoveButton;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.Apple:
                Player.Instance.IncreaseHealth(item.value);
                break;
            case Item.ItemType.Rock:
                Player.Instance.IncreaseExp(item.value);
                break;
            case Item.ItemType.Wood:
                Player.Instance.IncreaseExp(item.value);
                break;
        }

        RemoveItem();
    }

    
}
