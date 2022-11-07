using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestManager : MonoBehaviour
{

    public int activeQuestID;

    public bool startButtonPressed = false;

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
        if (UIactiveQuest != null)// transformar em funcao
        {
            foreach (var _quest in quests)
            {
                if (_quest.isStarted)
                {
                    activequestTitle.text = string.Format("Quest Title: {0}", _quest.questTitle);
                    activequestDescription.text = _quest.questDescription;
                    activeQuestItemImg.sprite = _quest.requestItem.data.icon;
                    isFindItemToggle.isOn = _quest.isGetItem;
                }
                if (_quest.isFinishQuest)
                {
                    _quest.resetQuest();
                    UIactiveQuest.SetActive(false);
                    startButtonPressed = false;
                    SpanwItenByName(_quest.rewardItem, _quest.spawnItemLocation.position);
                }
            }
        }
        
    }


    private void SpanwItenByName(Item itemToReward, Vector3 spawnLocation)
    {
        itemToReward = GameManager.instance.itemManager.GetItemByName(itemToReward.data.itemName);

        if (itemToReward != null)
        {

            Item droppedItem = Instantiate(itemToReward, spawnLocation, Quaternion.identity);

        }
    }

    public void QuestButtonByID(string behavoior) //Inicia ou Termina uma quest de acordo com a string behavior (Id de cada NPC quest)
    {

        startButtonPressed = true;

        UIactiveQuest.SetActive(true);// habilita a UI de quest Ativa *SOM

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
