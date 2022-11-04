using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quest : MonoBehaviour
{
    public int questId;

    public bool isStarted;
    public bool isFinish;
    public string questName;
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
        Debug.Log("Iniciou a quest da "+questName);
        isStarted = true;
    }

    public void cancellQuest()
    {
        Debug.Log("Cancelou a quest da" + questName);
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
            GetComponentInParent<QuestManager>().questTitle.text = questName;
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
