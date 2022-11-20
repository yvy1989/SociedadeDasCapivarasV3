using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIQuestManager : MonoBehaviour
{
    public GameObject ActiveQuestPanel;
    public GameObject goalPrefabPanel;
    public Transform GoalsSpacer;

    public Goal[] Goals;

    public int CurrentQuest_id;

    /// LOG PANEL ////////////////////////////
    public GameObject logPanel;
    public TextMeshProUGUI LogQuestDescription;
    public Button AcceptQuestBtn;
        

    public static UIQuestManager Instance;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ActiveQuestPanel.SetActive(!ActiveQuestPanel.active);
        }
    }


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

        foreach (var _goal in Goals)// varre a lista de goals e instancia um painel para cada objetivo da quest
        {
            GameObject goalPanel = Instantiate(goalPrefabPanel, GoalsSpacer);
            goalPanel.GetComponent<UIGoal>().TxtGoalDescription.text = _goal.description;
            goalPanel.GetComponent<UIGoal>().goalStatusToogle.isOn = _goal.isComplete;

        }
        
    }
}
