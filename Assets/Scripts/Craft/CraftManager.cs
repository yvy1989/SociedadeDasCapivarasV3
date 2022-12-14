using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System;

public class CraftManager : MonoBehaviour
{

    public Player p;

    public GameObject CraftMenuPanel;

    public Transform SpawnLocation;

    public CinemachineFreeLook cam; //camera do cinemachine para travar o freelock durante o menu de craft



    private void Start()
    {
        p = new Player();
    }

    public bool checkItem(string itemName, int itemAmount)// BUG************** o player perde o item mesmo sem craftar
    {
        if (p.inventory != null)
        {
            foreach (var _slot in p.inventory.slots)
            {
                if (_slot.itemName == itemName && _slot.count>=itemAmount)
                {

                    Debug.Log("Tem os itens");
                    
                    return true;
                }
            }
        }
        Debug.Log(string.Format("Nao possui {0}, ou a quantidade nao e suficiente", itemName));
        return false;
    }

    public void checkAndRemoveItem(string itemName, int itemAmount)// TESTE
    {
        if (p.inventory != null)
        {
            foreach (var _slot in p.inventory.slots)
            {
                if (_slot.itemName == itemName && _slot.count >= itemAmount)
                {
                    for (int i = 0; i < itemAmount; i++)
                    {
                        _slot.RemoveItem();
                    }
                }
            }
        }
    }

    public void craftItem(string itemName)
    {
        switch (itemName)
        {
            case "Axe":
                {
                    if (checkItem("Log", 2) && checkItem("Rock", 1))
                    {
                        checkAndRemoveItem("Log", 2);   ///teste
                        checkAndRemoveItem("Rock", 1);  ///teste

                        Debug.Log("CRIOU MACHADO");
                        SpanwItenByName(itemName);
                        SoudManager.PlaySound(SoudManager.SoudType.Craft);
                    }

                    
                    break;
                }
          
            case "Backpack":
                {
                    Debug.Log("CRIOU MOCHILA");
                    break;
                }
            default:
                break;

        }
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
