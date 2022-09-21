using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
    public void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Debug.Log(Item.name);
        //InventoryManager.Instance.List();
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
        
    }
}
