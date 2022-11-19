using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIQuestManager : MonoBehaviour
{
    public GameObject ActiveQuestPanel;

    public int CurrentQuest_id;

    /// LOG PANEL ////////////////////////////
    public GameObject logPanel;
    public TextMeshProUGUI LogQuestDescription;
    public Button AcceptQuestBtn;
        

    public static UIQuestManager Instance;



    public void startQuestByID()
    {
        QuestSM[] Quests = GetComponentsInChildren<QuestSM>();
        if (Quests != null)
        {
            foreach (var _quest in Quests)
            {
                if(_quest.questID == CurrentQuest_id)
                {
                    _quest.isQuestActive = true;
                }
            }

        }
        
    }
}
