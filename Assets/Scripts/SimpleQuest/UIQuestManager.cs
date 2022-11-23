using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIQuestManager : MonoBehaviour
{
    public bool activeQestComplete;

    //ACTIVE PANEL

    public Toggle QuestStatusToogle;
    public GameObject ActiveQuestPanel;
    public GameObject goalPrefabPanel;
    public Transform GoalsSpacer;
    public Goal[] Goals;
    List<GameObject> goalPanels = new List<GameObject>();


    public int CurrentQuest_id;

    /// LOG PANEL ////////////////////////////
    public GameObject logPanel;
    public TextMeshProUGUI LogQuestDescription;
    public Button AcceptQuestBtn;
        

    public static UIQuestManager Instance;

    QuestSM[] Quests;


    public void startQuestByID()
    {
        Quests = GetComponentsInChildren<QuestSM>();
        if (Quests != null)
        {
            foreach (var _quest in Quests)
            {
                if(_quest.questID == CurrentQuest_id)
                {
                    _quest.progress = QuestSM.QuestProgress.ACCEPTED; //aceita a quest
                }
            }

        }

        foreach (Goal _goal in Goals)// varre a lista de goals e instancia um painel para cada objetivo da quest
        {
            GameObject goalPanel = Instantiate(goalPrefabPanel, GoalsSpacer);
            goalPanel.GetComponent<UIGoal>().TxtGoalDescription.text = _goal.description;
            goalPanel.GetComponent<UIGoal>().goalStatusToogle.isOn = _goal.isComplete;
            goalPanel.GetComponent<UIGoal>().goalIndex = _goal.goalIndex;
            goalPanels.Add(goalPanel);

        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))// abre o painel de quest ativa
        {
            ActiveQuestPanel.SetActive(!ActiveQuestPanel.active);
        }


        if(activeQestComplete== false) // entra aqui se a quest ainda nao estiver terminada
        {
            if (goalPanels != null)
            {
                foreach (Goal _goal in Goals)
                {
                    foreach (var _goalPanel in goalPanels)
                    {
                        if (_goal.goalIndex == _goalPanel.GetComponent<UIGoal>().goalIndex)
                        {
                            _goalPanel.GetComponent<UIGoal>().goalStatusToogle.isOn = _goal.isComplete;
                        }
                    }
                }
            }


            if (Quests != null)
            {
                foreach (var _quest in Quests)
                {
                    if (_quest.questID == CurrentQuest_id)
                    {
                        activeQestComplete = _quest.complete;
                        QuestStatusToogle.isOn = activeQestComplete;
                    }
                }

            }
        }
        
    }


}
