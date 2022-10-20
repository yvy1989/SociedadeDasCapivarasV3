using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;

    public List<Slot_UI> slots = new List<Slot_UI>();


    private Slot_UI selectedSlot;



    private void OnEnable()
    {
        Collectable.ItemCollected += Refresh;
        CraftManager.ItemRemoved += Refresh;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            toggleInvetory();
        }

        CheckAlphanumericKeys();

    }


    public void toggleInvetory()
    {
        if (!inventoryPanel.activeSelf)//ser o inventario NAO estiver ativo
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else //se estiver ativo
        {
            inventoryPanel.SetActive(false);
        }
    }

    public void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(int slotID)
    {

        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(player.inventory.slots[slotID].itemName);


        if (itemToDrop != null)
        {
            player.DropItem(itemToDrop);
            player.inventory.Remove(slotID);
            Refresh();
        }
    }

    public void UseItem(int slotID) //REMOVE O ITEM SEM DROPAR PARA SIMULAR O USO///////////////////////
    {
        Item itemToUse = GameManager.instance.itemManager.GetItemByName(player.inventory.slots[slotID].itemName);
        if (itemToUse != null)
        {
            
            player.inventory.Remove(slotID);
            Refresh();
        }
    } //USO DO ITEM///////////////////////



    private void CheckAlphanumericKeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectSlot(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectSlot(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectSlot(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectSlot(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SelectSlot(8);
        }
    }


    public void SelectSlot(int index) //USO DO ITEM///////////////////////
    {
        if (slots.Count == 9)//////QTD de slots
        {
            selectedSlot = slots[index];

            
            if (selectedSlot != null)
            {
                if(selectedSlot.itemType == "craft")
                {
                    Debug.Log("Item de craft");
                    GameManager.instance.itemManager.setItemToPlayer(selectedSlot);
                }
                else
                {
                    selectedSlot.Interact();/// chamada do metodo de interface iteracao()

                    //REMOVE O ITEM SEM DROPAR///////////////////////
                    selectedSlot.SetEmpty();
                    UseItem(index);
                    /////////////////////////
                }


            }
        }
    }

}
