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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void QuestButtonByID(string behavoior) //Inicia ou Termina uma quest de acordo com a string behavior
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
