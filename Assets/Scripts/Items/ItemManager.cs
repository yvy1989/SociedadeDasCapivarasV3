using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item[] items;

    private Dictionary<string, Item> nameToItemDict = 
        new Dictionary<string, Item>();

    private void Awake()
    {
        foreach (Item item in items)
        {
            AddItem(item);
        }
    }

    private void AddItem(Item item)
    {
        if (!nameToItemDict.ContainsKey(item.data.itemName))
        {
            nameToItemDict.Add(item.data.itemName, item);
        }
    }

    public Item GetItemByName(string key)
    {
        if (nameToItemDict.ContainsKey(key))
        {
            return nameToItemDict[key];
        }

        return null;
    }

    /// <summary>
    /// Coloca um item na mao do player recebendo um slot onde tem o item como parametro
    /// </summary>
    /// <param name="selectedSlot"></param>
    public void setItemToPlayer(Slot_UI selectedSlot)
    {
        if (GameManager.instance.player.isHoldItem == false)
        {
            GameManager.instance.player.isHoldItem = true;
            Item CraftedItem = GameManager.instance.itemManager.GetItemByName(selectedSlot.itemName);
            Item SpawnCraftedItem = Instantiate(CraftedItem, GameManager.instance.player.itemPlaceHolder.position, Quaternion.identity);
            SpawnCraftedItem.transform.forward = GameManager.instance.player.itemPlaceHolder.forward;
            SpawnCraftedItem.transform.position += new Vector3(0.02f, -0.17f, 0);
            SpawnCraftedItem.transform.Rotate(90, 90, 0);
            SpawnCraftedItem.transform.SetParent(GameManager.instance.player.itemPlaceHolder);
            SpawnCraftedItem.GetComponent<BoxCollider>().enabled = false;// desativa o colisor do objeto de mao quando ele estiver na mao (for seguravel) e previne de aumentar a quantidade desse item quando pegar outro


        }
        else
        {
            Debug.Log("Player esta com item na mao");
        }
        
    }
}
