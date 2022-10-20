using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    public bool isEmpty = true;
    public Image itemIcon;
    public TextMeshProUGUI quantityText;
    Item itemSlot;

    //TESTE PICKUP ITEM
    public string itemType;
    public string itemName;
    //

    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            isEmpty =false;
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            quantityText.text = slot.count.ToString();
            itemSlot = slot.itemSlot;
            itemType = slot.itemSlot.data.itemType;
            itemName = slot.itemSlot.data.itemName;
        }
    }

    public void SetEmpty()
    {
        isEmpty = true;
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
    }


    public void Interact()
    {
        if (this.isEmpty==false) 
        {
            //CHAMADA DE SOM DO USO
            itemSlot.interactable.Interact();
        }

    }


}
