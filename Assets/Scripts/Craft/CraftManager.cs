using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CraftManager : MonoBehaviour
{
    public Player p;

    public GameObject CraftMenuPanel;

    public Transform SpawnLocation;

    public CinemachineFreeLook cam; //camera do cinemachine para travar o freelock durante o menu de craft

    public CraftedItem[] craftedItem;

    public static event Action ItemRemoved;

    private void Start()
    {
        p = new Player();
    }
    public bool checkItem(string name)// verifica se o player possui o item para o craft
    {
        if (p.inventory != null)
        {
            foreach (var item in p.inventory.slots)
            {
                if(item.itemName == name)
                {
                    return true;
                }   
            }           
        }
        return false;
    }


    public void craftItem(string itemName)
    {
        //verificar se possui os itens////////////////////////////////////////////////////

        foreach (var _craftedItem in craftedItem)
        {
            if (_craftedItem.name == itemName)
            {
                foreach (var _necItens in _craftedItem._necessaryItens)
                {

                    if (checkItem(_necItens.itemName))
                    {
                        
                        //REFRESH
                        if (ItemRemoved != null)
                        {
                            ItemRemoved();
                        }
                        //
                    }
                    else
                    {
                        Debug.Log("VOCE NAO POSSUI ITENS SUFICIENTES " );
                        return;
                    }
                }


            }
            else
            {
                return;
            }

        }
        /////remove os itens//////////////////////////////////////////////////////////////////////////////

        foreach (var _craftedItem in craftedItem)
        {
            foreach (var _necItens in _craftedItem._necessaryItens)
            {
                p.inventory.RemoveByName(_necItens.itemName);
                //REFRESH
                if (ItemRemoved != null)
                {
                    ItemRemoved();
                }
                //
            }

        }

        /////////////////spawna o item
        SpanwItenByName(itemName);
    }

    private void SpanwItenByName(string itemName)
    {
        Item itemToDrop = GameManager.instance.itemManager.GetItemByName(itemName);

        if (itemToDrop != null)
        {
            Vector3 spawnLocation = SpawnLocation.position;

            Item droppedItem = Instantiate(itemToDrop, spawnLocation, Quaternion.identity);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Player p = other.transform.GetComponent<Player>();
        p = other.transform.GetComponent<Player>();
        if (p != null)
        {
            //checkItem("Apple", 1, p.inventory);

            if (CraftMenuPanel!=null) CraftMenuPanel.SetActive(true);

            if (cam != null) {
                cam.m_YAxis.m_MaxSpeed = 0;
                cam.m_XAxis.m_MaxSpeed = 0;
            } 
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();
        if (p != null)
        {
            if (CraftMenuPanel != null) CraftMenuPanel.SetActive(false);

            if (cam != null)
            {
                cam.m_YAxis.m_MaxSpeed = 5;
                cam.m_XAxis.m_MaxSpeed = 300;
            }

        }
    }

}
