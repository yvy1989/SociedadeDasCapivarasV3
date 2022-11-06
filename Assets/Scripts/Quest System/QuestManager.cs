using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestManager : MonoBehaviour
{

    public int activeQuestID;


    public GameObject UIQuest;
    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;

    ///ACTIVE QUEST UI////
    public GameObject UIactiveQuest;
    public TextMeshProUGUI activequestTitle;
    public TextMeshProUGUI activequestDescription;
    public Image activeQuestItemImg;
    public Toggle isFindItemToggle;

    //////////////////////

    public Quest[] quests;

    // Start is called before the first frame update
    void Start()
    {
        quests = GetComponentsInChildren<Quest>();       
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var _quest in quests)
        {
            if (_quest.isStarted)
            {
                //colocar os dados na UI
                activequestTitle.text = string.Format("Quest Title: {0}", _quest.questTitle);
                activequestDescription.text = _quest.questDescription;
                activeQuestItemImg.sprite = _quest.requestItem.data.icon;
                isFindItemToggle.isOn = _quest.isFinish; 
            }
        }
    }


    public void QuestButtonByID(string behavoior) //Inicia ou Termina uma quest de acordo com a string behavior (Id de cada NPC quest)
    {
        Quest[] quests = GetComponentsInChildren<Quest>();

        foreach (var quest in quests)
        {
            if (quest.questId == activeQuestID)
            {
                if (behavoior=="start") {
                    quest.startQuest();
                }
                if (behavoior == "end")
                {
                    quest.cancellQuest();
                }
            }
        }

    }
}
