using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
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
        isStarted = true;
    }

    public void cancellQuest()
    {
        isStarted = false;
    }

    public void finishQuest()
    {
        isFinish = true;
        //entrgar o item qundo finalizar a quest
    }
}
