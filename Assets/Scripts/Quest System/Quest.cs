using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quest : MonoBehaviour
{
    public int questId;

    public bool isStarted;
    public bool isFinish;
    public string questTitle;
    public string questDescription;

    public Transform spawnItemLocation;
    public Item rewardItem;
    public Item requestItem;
    


    private void Start()
    {
        isStarted = false;
        isFinish = false;


    }


    public void startQuest()
    {
        Debug.Log("Iniciou a quest da "+questTitle);       
        isStarted = true;
        StartCoroutine(checkRequestItem());//Verificar constantemente se o player pegou o item da quest
    }

    

    IEnumerator checkRequestItem()// verifica se o player tem o item da quest no inventario a cada 0.1 segundos
    {
        while (true)
        {
            foreach (var slot in Player.Instance.inventory.slots)
            {
                if(slot.itemName == requestItem.data.name)
                {
                    Debug.Log("Tem o item!!!");
                    finishQuest();
                    
                    StopAllCoroutines();
                }
            }

            
            yield return new WaitForSeconds(0.1f);
        }
    }


    

    public void cancellQuest()
    {
        Debug.Log("Cancelou a quest da" + questTitle);
        isStarted = false;
    }

    public void finishQuest()
    {
        isFinish = true;
        //entrgar o item qundo finalizar a quest
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            GetComponentInParent<QuestManager>().UIQuest.SetActive(true);
            GetComponentInParent<QuestManager>().questTitle.text = questTitle;
            GetComponentInParent<QuestManager>().questDescription.text = questDescription;
            GetComponentInParent<QuestManager>().activeQuestID = questId;


        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            GetComponentInParent<QuestManager>().questTitle.text = "";
            GetComponentInParent<QuestManager>().questDescription.text = "";
            GetComponentInParent<QuestManager>().UIQuest.SetActive(false);
            GetComponentInParent<QuestManager>().activeQuestID = -1;
        }

    }
}
